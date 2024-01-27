using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class NoteScript : Collidable
{
    public float tempo = 1;
    

    public NoteData NoteData;
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        transform.Translate(Vector3.left * tempo  * Time.deltaTime);
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (GameController.instance.currentlyPressing == null)
        {
            return; // dont play sound if nothing is pressed
        }
        
        if (GameController.instance.currentlyPressing == NoteData.Key)
        {
            Debug.Log("playing");
            if (!AudioController.instance.IsPlaying(NoteData.Note))
            {
                AudioController.instance.Play(NoteData.Note);
            }
        }
        else
        {
            // Play "wrong sound"
            if (!AudioController.instance.IsPlaying("boo_short_1"))
            {
                AudioController.instance.Play("boo_short_1");
                Debug.Log("Wrong");
                GameController.instance.FailNote();
            }
        }
    }
}
