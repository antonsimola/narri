using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthUi : MonoBehaviour
{
    [SerializeField]
    private TMP_Text PlayerHealthField;
    
    void Start()
    {
        PlayerHealthField.text = GameController.instance.GetPlayerHealth().ToString();
        GameController.instance.OnPlayerDamageTaken += DisplayNewHealth;
    }

    private void DisplayNewHealth(int newHealth)
    {
        PlayerHealthField.text = newHealth.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
