using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    [SerializeField]
    private Scores scores;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddNewScore(string name)
    {
        Score newScore = new Score();
        newScore.Id = Guid.NewGuid().ToString();
        newScore.Name = name;
        newScore.TimeSurvived = 0;  
        scores.AllScores.Insert(0, newScore);

        if (scores.AllScores.Count >= 6)
        {
            scores.AllScores.RemoveAt(scores.AllScores.Count - 1);
        }
    }

    public List<Score> GetScores()
    {
        return scores.AllScores;
    }

    public void RemoveFromFirst()
    {
        scores.AllScores.RemoveAt(0);
    }

    public void AddTimeToScore(int index, int time)
    {
        scores.AllScores[index].TimeSurvived = time;
    }

}
