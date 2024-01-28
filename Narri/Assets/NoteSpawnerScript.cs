using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class NoteSpawnerScript : MonoBehaviour
{
    private float gameTime = 0;
    [SerializeField] float tempo = 90;

    [SerializeField] public NoteScript NotePrefab;
    [SerializeField] public PlayLineControlScript PlayLineControl;

    private bool gameStarted = true;


    public IList<NoteData> Song2 = new List<NoteData>()
    {
        new NoteData() { Note = "e3", StartTime = 0, Key = 4 },
        new NoteData() { Note = "d3", StartTime = 0.5f, Key = 3 },
        new NoteData() { Note = "c3", StartTime = 1.0f, Key = 2 },
        new NoteData() { Note = "b2", StartTime = 1.5f, Key = 1 },

        new NoteData() { Note = "b2", StartTime = 2.5f, Key = 1 },
        new NoteData() { Note = "c3", StartTime = 3.0f, Key = 2 },
        new NoteData() { Note = "d3", StartTime = 3.5f, Key = 3 },
        new NoteData() { Note = "e3", StartTime = 4.0f, Key = 4 },
        
        new NoteData() { Note = "c3", StartTime = 4.5f, Key = 2 },
        new NoteData() { Note = "a2", StartTime = 5.0f, Key = 0 },
    };



    private List<NoteScript> NoteObjs = new List<NoteScript>();


    // Start is called before the first frame update
    void Start()
    {

        var songIdx = GameController.instance.SongIndex % Songs.SongList.Count;
        var song = Songs.SongList[songIdx];
        PlayLineControl.noteTotalCount = song.Notes.Count;
        foreach (var note in song.Notes)
        {
            StartCoroutine(QueueNote(tempo, note));
        }
    }

    IEnumerator QueueNote(float tempo, NoteData notedata)
    {
        var tempoDiff = tempo + GameController.instance.NoteGameDifficulty;

        yield return new WaitForSeconds(tempoDiff / 60f * notedata.StartTime);
        var obj = Instantiate(NotePrefab,
            new Vector3(3, (5 - notedata.Key + GameController.YOffset) * 0.32f + 0.16f, 0),
            Quaternion.identity);
        obj.NoteData = notedata;
        NoteObjs.Add(obj);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDestroy()
    {
        foreach (var note in NoteObjs)
        {
            Destroy(note.gameObject);
        }
    }
}