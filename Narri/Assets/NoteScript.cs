using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : Collidable
{
    public float speed = 1;
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("Holding L");
        }

        transform.Translate(Vector3.left * speed  * Time.deltaTime);
    }

    protected override void OnCollide(Collider2D coll)
    {
        base.OnCollide(coll);
        Debug.Log("collide");
        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("playing");
            if (AudioController.instance.IsPlaying("e3"))
            {
                AudioController.instance.Play("e3");
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hello");
    }
    
}
