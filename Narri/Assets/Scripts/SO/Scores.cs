using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Scores : ScriptableObject
{

    [field: SerializeField]
    public List<Score> AllScores = new List<Score>();
  
}

[System.Serializable]
public class Score
{
    public string Id;
    public string Name;
    public float TimeSurvived;
}