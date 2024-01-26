using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    public BoxCollider2D boxCollider;
    public CircleCollider2D circleCollider;
    private Collider2D[] hits = new Collider2D[10];
    private int nullCOunt = 0;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        if (boxCollider == null && circleCollider == null)
        {
            return;
        }

        if (boxCollider != null)
        {
            boxCollider.OverlapCollider(filter, hits);
        }
        else if (circleCollider != null)
        {
            circleCollider.OverlapCollider(filter, hits);
        }

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                nullCOunt++;
                continue;
            }

            OnCollide(hits[i]);

            //clean
            hits[i] = null;

        }

        if (nullCOunt == 10)
        {
            NoCollisions();
        }
        nullCOunt = 0;
    }

    protected virtual void OnCollide(Collider2D coll)
    {

    }

    protected virtual void NoCollisions()
    {

    }

    // Called when a collision ends
    protected virtual void OnCollisionExit2D(Collision2D coll)
    {

    }

}
