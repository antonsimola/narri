using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerSurvivedUi : MonoBehaviour
{

    [SerializeField]
    private TMP_Text TimeSurvivedField;
    public float started = 0;
    public float timeSurvived = 0;  

    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.onGameStarted += StartTimer;
        GameController.instance.onGameEnded += EndTimer;
    }

    private void StartTimer()
    {
        started = Time.time;
    }

    private void EndTimer()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        int survived = (int)(Time.time - started);
        TimeSurvivedField.text = survived.ToString();
    }
}
