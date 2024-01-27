using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class King : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private Rigidbody2D rb;


    private EPos kingpos = EPos.MIDDLE;
   
    private bool isMoving = false;
    [SerializeField]
    private float timeLeft = 5;
    private float countDownTimer;

    private float target = 0;

    private int steps = 15;

   

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - countDownTimer > timeLeft)
        {
            isMoving = false;
        }

        MoveKing();
    }

    private void MoveKing()
    {
        if (!isMoving)
        {
            float newXpos = transform.position.x;

            if (kingpos == EPos.MIDDLE)
            {
                System.Random rand = new System.Random();
                int randNum = rand.Next(2);

                if (randNum == 0)
                {
                    // move right
                    kingpos = EPos.RIGHT;
                    newXpos = newXpos + steps;
                    transform.localScale = new Vector3(-1, 1, 1);
                    
                }
                else
                {
                    // move left
                    kingpos = EPos.LEFT;
                    newXpos = newXpos - steps;
                    transform.localScale = Vector3.one;
                }
            }
            else if (kingpos == EPos.LEFT)
            {
                kingpos = EPos.RIGHT;
                newXpos = newXpos + steps;
                transform.localScale = new Vector3(-1, 1, 1);
                
            }
            else if(kingpos == EPos.RIGHT)
            {
                kingpos = EPos.LEFT;
                newXpos = newXpos - steps;
                transform.localScale = Vector3.one;
            }

            target = newXpos;
            isMoving = true;
            countDownTimer = Time.time;
        }


       
        Vector3 movement = new Vector3(target, transform.position.y, 0).normalized;
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