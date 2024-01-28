using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private List<Score> ScoreList;

    [SerializeField]
    private TMP_Text name1;
    [SerializeField]
    private TMP_Text name2;
    [SerializeField]
    private TMP_Text name3;
    [SerializeField]
    private TMP_Text name4;
    [SerializeField]
    private TMP_Text name5;


    [SerializeField]
    private TMP_Text score1;
    [SerializeField]
    private TMP_Text score2;
    [SerializeField]
    private TMP_Text score3;
    [SerializeField]
    private TMP_Text score4;
    [SerializeField]
    private TMP_Text score5;

    // Start is called before the first frame update
    void Start()
    {
        ScoreList = ScoreController.instance.GetScores();
        if (ScoreList.Count > 0)
        {
            name1.text = ScoreList[0].Name;
            score1.text = ScoreList[0].TimeSurvived.ToString();
        }
        if (ScoreList.Count > 1)
        {
            name2.text = ScoreList[1].Name;
            score2.text = ScoreList[1].TimeSurvived.ToString();
        }
        if (ScoreList.Count > 2)
        {
            name3.text = ScoreList[2].Name;
            score3.text = ScoreList[2].TimeSurvived.ToString();
        }
        if (ScoreList.Count > 3)
        {
            name4.text = ScoreList[3].Name;
            score4.text = ScoreList[3].TimeSurvived.ToString();
        }
        if (ScoreList.Count > 4)
        {
            name5.text = ScoreList[4].Name;
            score5.text = ScoreList[4].TimeSurvived.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
