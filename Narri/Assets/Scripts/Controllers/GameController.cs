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


    

    public MiniGameEnum MiniGameToStart = MiniGameEnum.Note;
    private GameObject currentMiniGameObj;


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
    }

    // Update is called once per frame
   

    
    

    public void StartNewMiniGame()
    {

        if (MiniGameToStart == MiniGameEnum.Note)
        {

            currentMiniGameObj =  Instantiate(NoteMiniGame);
            
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
        //if u need do something on dead
        SceneController.instance.ChangeScene(2);
    }

    public void FailWord()
    {
        OnPlayerDamageTaken?.Invoke(RedusePlayerHealth(damageOnFail));
    }
    
    public void FailNote()
    {
        //TODO decrement fail counter
        OnPlayerDamageTaken?.Invoke(RedusePlayerHealth(damageOnFail));
    }

    public void EndMiniGame()
    {
        Destroy(currentMiniGameObj);
        if (MiniGameToStart == MiniGameEnum.Joke)
        {
            MiniGameToStart = MiniGameEnum.Note;
        }
        else if (MiniGameToStart == MiniGameEnum.Note)
        {
            MiniGameToStart = MiniGameEnum.Joke;
        }
       
        onMiniGameEnded?.Invoke();
        Debug.Log("End mini game");
    }
}