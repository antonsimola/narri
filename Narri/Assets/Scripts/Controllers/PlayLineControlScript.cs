using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLineControlScript : MonoBehaviour
{
    public PlayLineScript playLinePrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < 5; i++)
        {
            var playLine =  Instantiate(playLinePrefab, new Vector3(-4, i-2, 0), Quaternion.identity);
            playLine.Key = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
