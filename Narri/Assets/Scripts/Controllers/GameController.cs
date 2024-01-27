using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int playerHealth = 100;

    [SerializeField]
    private int damageOnFail = 10;

    public static GameController instance;

    [SerializeField] public GameObject NoteMiniGame;

    public static int YOffset = -3;
    
    public static IDictionary<int, KeyCode> KeyMap = new Dictionary<int, KeyCode>()
    {
        { 0, KeyCode.G },
        { 1, KeyCode.H },
        { 2, KeyCode.J },
        { 3, KeyCode.K },
        { 4, KeyCode.L },
    };

    public int? currentlyPressing;

    // call ->  OnPlayerDamageTaken?.Invoke(newHealt);
    public event Action<int> OnPlayerDamageTaken;


    public PlayLineScript[] PlayLineSegments = new PlayLineScript[5];


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
    }

    // Update is called once per frame
    void Update()
    {
        currentlyPressing = null;
        if (PlayLineSegments[0] == null) return;
        
        foreach (var kv in KeyMap)
        {
            
            if (Input.GetKey(kv.Value))
            {
                currentlyPressing = kv.Key;
            }
        }
        
        foreach (var kv in KeyMap)
        {
            
            if (Input.GetKeyDown(kv.Value))
            {
                var segment = PlayLineSegments[kv.Key];
                if (!segment.IsColliding)
                {
                    AudioController.instance.Play("boo_short_1");
                    FailNote();
                    return;
                }
                else
                {
                    if (GameController.instance.currentlyPressing == segment.CollidingNote.NoteData.Key)
                    {
                        
                        segment.CollidingNote.SetOk();
                    }
                    else
                    {
                        AudioController.instance.Play("boo_short_1");
                        FailNote();
                    }
                }
            }
        }
        
      

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Exit");
            SceneController.instance.ChangeScene(0);
        }
    }

    public void FailNote()
    {
        //TODO decrement fail counter
        OnPlayerDamageTaken?.Invoke(RedusePlayerHealth(damageOnFail));
    }

    public void StartNoteMiniGame()
    {
        NoteMiniGame.SetActive(true);
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

}