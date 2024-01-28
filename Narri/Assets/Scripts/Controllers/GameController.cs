using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Utility;
using UnityEngine;
using Random = System.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;

    [SerializeField] private int damageOnFail = 10;

    public static GameController instance;

    [SerializeField] public GameObject NoteMiniGame;
    [SerializeField] public GameObject JokeMiniGame;

    public Random Random = new Random((int)DateTime.Now.Ticks % 10000000);

    public static int YOffset = -3;

    // call ->  OnPlayerDamageTaken?.Invoke(newHealt);
    public event Action<int> OnPlayerDamageTaken;
    public event Action onMiniGameEnded;
    public event Action onGameStarted;
    public event Action onGameEnded;


    public MiniGameEnum MiniGameToStart = MiniGameEnum.Note;
    private GameObject currentMiniGameObj;

    public float NoteGameDifficulty = 0;
    public float JokeGameDifficulty = 0;
    public float JokeGameDifficultyMoveSpeed = 0;
    private bool firstMinigame = true;
    [SerializeField] public int SongIndex = 0;
    private bool firstTimeNote = true;
    private bool firstTimeJoke = true;

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

    // Start is called before the first frame update
    void Start()
    {
        Random rand = new Random();
        int randNum = rand.Next(2);
        MiniGameToStart = (MiniGameEnum)randNum;
        if (MiniGameToStart == MiniGameEnum.Joke)
        {
            firstTimeJoke = false;
        }

        if (MiniGameToStart == MiniGameEnum.Note)
        {
            firstTimeNote = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScoreController.instance.RemoveFromFirst();
            SceneController.instance.ChangeScene(0);
        }
    }


    public void StartNewMiniGame()
    {

        if (firstMinigame)
        {
            onGameStarted?.Invoke();
            firstMinigame  = false;
        }

        if (MiniGameToStart == MiniGameEnum.Note)
        {
            currentMiniGameObj = Instantiate(NoteMiniGame);
        }
        else if (MiniGameToStart == MiniGameEnum.Joke)
        {
            currentMiniGameObj = Instantiate(JokeMiniGame);
        }
    }


    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    private int RedusePlayerHealth(int damageTaken)
    {
        playerHealth = playerHealth - damageTaken;
        if (playerHealth <= 0)
        {
            Die();
            return 0;
        }

        return playerHealth;
    }

    private void Die()
    {
        onGameEnded?.Invoke();
        SceneController.instance.ChangeScene(2);
    }

    public void FailWord()
    {
        AudioController.instance.PlayRandomWithPrefix("boo");
        OnPlayerDamageTaken?.Invoke(RedusePlayerHealth(damageOnFail));
    }

    public void FailNote()
    {
        AudioController.instance.PlayRandomWithPrefix("fail");
        //TODO decrement fail counter
        OnPlayerDamageTaken?.Invoke(RedusePlayerHealth(damageOnFail));
    }

    public void EndMiniGame()
    {
        Debug.Log("EndMiniGame");
        
        AudioController.instance.PlayRandomWithPrefix("laugh");
        Destroy(currentMiniGameObj);
        if (MiniGameToStart == MiniGameEnum.Joke)
        {
            if (firstTimeNote)
            {
                firstTimeNote = false;
            }
            else
            {
                NoteGameDifficulty -= 10;
                SongIndex++;    
            }
            MiniGameToStart = MiniGameEnum.Note;
        }
        else if (MiniGameToStart == MiniGameEnum.Note)
        {
            if (firstTimeJoke)
            {
                firstTimeJoke = false;
            }
            else
            {
                JokeGameDifficulty -= 0.5f; 
                JokeGameDifficultyMoveSpeed += 0.5f;    
            }
             
            MiniGameToStart = MiniGameEnum.Joke;
        }

        onMiniGameEnded?.Invoke();
        Debug.Log("End mini game");
    }
}