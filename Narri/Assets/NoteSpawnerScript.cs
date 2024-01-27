using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class NoteSpawnerScript : MonoBehaviour
{
    private float gameTime = 0;


    [SerializeField] public NoteScript NotePrefab;

    private bool gameStarted = true;

    public IList<NoteData> Notes = new List<NoteData>()
    {
        new NoteData() { Note = "e3", StartTime = 0, Key = 1 },
        new NoteData() { Note = "b2", StartTime = 2, Key = 2 },
        new NoteData() { Note = "c3", StartTime = 3, Key = 3 },
        new NoteData() { Note = "d3", StartTime = 4, Key = 4 },
        new NoteData() { Note = "e3", StartTime = 6, Key = 0 },
        new NoteData() { Note = "e3", StartTime = 8, Key = 1 }
    };


    // Start is called before the first frame update
    void Start()
    {
        foreach (var note in Notes)
        {
            StartCoroutine(QueueNote(note));
        }
    }

    IEnumerator QueueNote(NoteData notedata)
    {
        yield return new WaitForSeconds(notedata.StartTime);
        var obj = Instantiate(NotePrefab, new Vector3(0, notedata.Key - 2, 0), Quaternion.identity);
        obj.NoteData = notedata;
    }

    // Update is called once per frame
    void Update()
    {
    }
}