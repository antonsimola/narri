using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayLineScript : Collidable
{

    [SerializeField] private TMP_Text NoteText;
    public int Key; // 0,1,2,3,4
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

    protected override void OnCollide(Collider2D coll)
    {
        base.OnCollide(coll);
        
    }

    public void SetText(string key)
    {
        NoteText.text = key;
    }
}
