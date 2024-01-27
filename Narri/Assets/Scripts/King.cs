using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class King : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private Rigidbody2D rb;


    private EPos kingpos = EPos.MIDDLE;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveKing();
    }

    private void MoveKing()
    {
        float newXpos = transform.position.x;

        if (kingpos == EPos.MIDDLE)
        {
            System.Random rand = new System.Random();
            int randNum = rand.Next(2);
            if (randNum == 0)
            {
                //move left
                kingpos = EPos.RIGHT;
                newXpos = newXpos = 20;
            }
        }
       

        Vector3 movement = new Vector3(newXpos, transform.position.y, 0).normalized;
        Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }
}


public enum EPos
{
    RIGHT,
    MIDDLE,
    LEFT
}