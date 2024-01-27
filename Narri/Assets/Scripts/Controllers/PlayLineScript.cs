using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayLineScript : Collidable
{

    [SerializeField] private TMP_Text NoteText;
    public int Key; // 0,1,2,3,4

    public bool IsColliding;
    public NoteScript CollidingNote = null;

    // Start is called before the first frame update
    void Start()
    {
           base.Start();
           
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public void OnTriggerStay2D(Collider2D coll)
    {
        IsColliding = true;
        this.CollidingNote = coll.gameObject.GetComponent<NoteScript>();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        IsColliding = false;
        CollidingNote = null;
    }
    


    public void SetText(string key)
    {
        NoteText.text = key;
    }

    public void SetKey(int key)
    {
        Key = key;
        GameController.instance.PlayLineSegments[key] = this;
    }
}
