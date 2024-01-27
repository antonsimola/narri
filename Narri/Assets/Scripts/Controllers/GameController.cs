using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int playerHealth = 100;

    [SerializeField]
    private int damageOnFail = 10;

    public static GameController instance;

    [SerializeField] public GameObject NoteMiniGame;

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
        foreach (var kv in KeyMap)
        {
            if (Input.GetKey(kv.Value))
            {
                currentlyPressing = kv.Key;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Exit");
            SceneController.instance.exitgame();
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
        throw new NotImplementedException();
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    private int RedusePlayerHealth(int damageTaken)
    {
        return playerHealth - damageTaken;
    }

}