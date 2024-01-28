using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Main_menu : MonoBehaviour
{

    [SerializeField]
    public TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        AudioController.instance.Play("bg_music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGame()
    {
        ScoreController.instance.AddNewScore(nameInput.text);
        SceneController.instance.ChangeScene(1);
    }

}
