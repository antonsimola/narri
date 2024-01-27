using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class NoteSpawnerScript : MonoBehaviour
{
    private float gameTime = 0;
    [SerializeField] public float tempo = 240;

    [SerializeField] public NoteScript NotePrefab;

    private bool gameStarted = true;

    public IList<NoteData> Notes = new List<NoteData>()
    {
        new NoteData() { Note = "e3", StartTime = 0, Key = 4 },
        new NoteData() { Note = "b2", StartTime = 1, Key = 1 },
        new NoteData() { Note = "c3", StartTime = 1.5f, Key = 2 },
        new NoteData() { Note = "d3", StartTime = 2, Key = 3 },

        new NoteData() { Note = "e3", StartTime = 2.5f, Key = 2 },
        new NoteData() { Note = "b2", StartTime = 2.75f, Key = 1 },
        new NoteData() { Note = "b2", StartTime = 3.0f, Key = 0 },
    };


    // Start is called before the first frame update
    void Start()
    {
        foreach (var note in Notes)
        {
            StartCoroutine(QueueNote(tempo, note));
        }
    }

    IEnumerator QueueNote(float tempo, NoteData notedata)
    {
        yield return new WaitForSeconds( tempo / 60f * notedata.StartTime);
        var obj = Instantiate(NotePrefab, new Vector3(0, 5 - notedata.Key + GameController.YOffset, 0),
            Quaternion.identity);
        obj.NoteData = notedata;
    }

    // Update is called once per frame
    void Update()
    {
    }
}