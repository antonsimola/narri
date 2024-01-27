using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLineScript : Collidable
{

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
}
