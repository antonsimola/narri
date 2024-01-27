using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLineControlScript : MonoBehaviour
{
    public PlayLineScript playLinePrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 4; i >= 0; i--)
        {
            var playLine =  Instantiate(playLinePrefab, new Vector3(-4, (5- i + GameController.YOffset) * 0.32f, 0), Quaternion.identity);
            playLine.SetKey(i);
            playLine.SetText(GameController.KeyMap[i].ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
