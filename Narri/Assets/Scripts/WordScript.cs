using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class WordScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private TMP_Text Word;
    public string _cleanWord;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);   
    }

    public void SetWord(string word)
    {
        Word.SetText(word);
    }
    
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        WordSpawnerScript.instance.OnWordHitWall(this);
    }
}
