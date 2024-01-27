using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class StartCounterUi : MonoBehaviour
{

    [SerializeField]
    private TMP_Text TimeCounter;
    
    [SerializeField]
    private float timeLeft = 5;
    private float countDownTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        TimeCounter.text = timeLeft.ToString();
        GameController.instance.onMiniGameEnded += StartNewCounter;
        countDownTimer = Time.time;
    }

    private void StartNewCounter()
    {
        gameObject.SetActive(true);
        TimeCounter.text = timeLeft.ToString();
        countDownTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - countDownTimer > timeLeft)
        {
            
            Debug.Log("Start game here");
            GameController.instance.StartNewMiniGame();    
            gameObject.SetActive(false);
        }
        else
        {
            var sec = Mathf.Round(Time.time - countDownTimer);
            TimeCounter.text = (timeLeft - sec).ToString();
        }
    }


}
