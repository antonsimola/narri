using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class NoteScript : Collidable
{
    public float speed = 1;

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
        transform.Translate(Vector3.left * speed  * Time.deltaTime);
    }

    protected override void OnCollide(Collider2D coll)
    {
        base.OnCollide(coll);
        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("playing");
            if (!AudioController.instance.IsPlaying(NoteData.Note))
            {
                AudioController.instance.Play(NoteData.Note);
            }
            
        }
    }
}
