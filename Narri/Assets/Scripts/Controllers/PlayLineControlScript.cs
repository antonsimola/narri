using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLineControlScript : MonoBehaviour
{
    public PlayLineScript playLinePrefab;

    [SerializeField] private Sprite failNote;

    public PlayLineScript[] PlayLineSegments = new PlayLineScript[5];

    public static IDictionary<int, KeyCode> KeyMap = new Dictionary<int, KeyCode>()
    {
        { 0, KeyCode.G },
        { 1, KeyCode.H },
        { 2, KeyCode.J },
        { 3, KeyCode.K },
        { 4, KeyCode.L },
    };


    public int handledNotes;
    public int noteTotalCount;
    public HashSet<GameObject> failedNotes = new();
    public HashSet<GameObject> okNotes = new();


    // Start is called before the first frame update
    void Start()
    {
        for (var i = 4; i >= 0; i--)
        {
            var playLine = Instantiate(playLinePrefab, new Vector3(-4, (5 - i + GameController.YOffset) * 0.32f, 0),
                Quaternion.identity);
            playLine.SetKey(i);
            playLine.SetText(KeyMap[i].ToString());
            playLine.control = this;
            PlayLineSegments[i] = playLine;
        }
    }

    private void OnDestroy()
    {
        foreach (var playLineSegment in PlayLineSegments)
        {
            Destroy(playLineSegment.gameObject);
        }
    }

    void Update()
    {
        int? currentlyPressing = null;
        if (PlayLineSegments[0] == null) return;

        foreach (var kv in KeyMap)
        {
            if (Input.GetKey(kv.Value))
            {
                currentlyPressing = kv.Key;
            }
        }


        foreach (var kv in KeyMap)
        {
            if (Input.GetKeyDown(kv.Value))
            {
                var segment = PlayLineSegments[kv.Key];
                if (!segment.IsColliding)
                {
                    FailNote();
                    return;
                }
                else
                {
                    if (currentlyPressing == segment.CollidingNote.NoteData.Key)
                    {
                        okNotes.Add(segment.CollidingNote.gameObject);
                        AudioController.instance.Play(segment.CollidingNote.NoteData.Note);
                        Destroy(segment.CollidingNote.gameObject);
                    }
                    else
                    {
                        failedNotes.Add(segment.CollidingNote.gameObject);
                        FailNote();
                    }
                }
            }
        }

        if (okNotes.Count + failedNotes.Count >= noteTotalCount)
        {
            GameController.instance.EndMiniGame();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Exit");
            SceneController.instance.ChangeScene(0);
        }
    }


    public void FailNote()
    {
        
        //TODO proper sound effect for failed note
        GameController.instance.FailNote();
    }

    public void ExitedPlayLine(Collider2D other)
    {
        if (failedNotes.Contains(other.gameObject))
        {
            return;
        }
        
        if (okNotes.Contains(other.gameObject))
        {
            return;
        }

        failedNotes.Add(other.gameObject);

        Debug.Log("Missed note");
        other.gameObject.GetComponent<SpriteRenderer>().sprite = failNote;


    }
}