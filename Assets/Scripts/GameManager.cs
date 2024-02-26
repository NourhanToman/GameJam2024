using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum RoomsAttempts
{
    ONE,
    TWO,
    THREE
}
public enum roomsRequirments
{
    none,
    book,
    BedroonPortal,
    FreedomPortal,
    JusticePortal,
    PeacePortal,
    box
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameStates state;
    public RoomsAttempts attempts;
    public roomsRequirments requirments;
    public GameObject PauseMenuPrefab;
    public PlayerState playerState;
   /* [HideInInspector] public int FreedomNoOfVisits = 0;
    [HideInInspector] public int PeaceNoOfVisits = 0;
    [HideInInspector] public int JusticeNoOfVisits = 0;*/
    [HideInInspector] public GameObject Player;
    [HideInInspector] public StarterAssetsInputs playerInputs;
    private bool PauseMenuExists = false;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        playerInputs = Player.GetComponent<StarterAssetsInputs>();
        state = GameStates.Bedroom;    
        attempts = RoomsAttempts.ONE;
        requirments = roomsRequirments.none;
        playerState = PlayerState.NotFree;
    }
    private void Update()
    {
        //Debug.Log(playerState);
        if (!PauseMenuExists)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UpdateGameState(GameStates.Pause);
            }
        }
    }
    public void UpdateGameState(GameStates states)
    {
        state = states;

        switch (state)
        {
            case GameStates.Bedroom:
                PauseMenuExists = false;
                SceneManager.LoadScene(1);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Trail:
                PauseMenuExists = false;
                SceneManager.LoadScene(2);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Justice:
                PauseMenuExists = false;
                //JusticeNoOfVisits++;
                SceneManager.LoadScene(3);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Peace:
                PauseMenuExists = false;
                //PeaceNoOfVisits++;
                SceneManager.LoadScene(5);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Freedom:
                PauseMenuExists = false;
                //FreedomNoOfVisits++;
                SceneManager.LoadScene(4);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Win:
                SceneManager.LoadScene(1);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Pause:
                PauseMenuExists = true;
                Instantiate(PauseMenuPrefab);
                break;
            case GameStates.Resume:
                break;

        }
    }

    public void UpdateRoomsRequirements(roomsRequirments req)
    {
        requirments = req;
        switch (req)
        {
            case roomsRequirments.none:
                playerState = PlayerState.NotFree;
                break;
            case roomsRequirments.FreedomPortal:
                playerState = PlayerState.NoHandCuf;
                break;
            case roomsRequirments.PeacePortal:
                state = GameStates.Bedroom;
                break;
            case roomsRequirments.JusticePortal: 
                playerState = PlayerState.NoCamShake;
                break;
        }
    }


    public void UpdateRoomsAttempts(RoomsAttempts attempt)
    {
        attempts = attempt;
        switch (attempt)
        {
            case RoomsAttempts.ONE:
                break;
            case RoomsAttempts.TWO:
                attempts = RoomsAttempts.TWO;
                break;
            case RoomsAttempts.THREE:
                attempts = RoomsAttempts.THREE;
                break;
        }
    }
}

public enum PlayerState
{
    NotFree,
    NoCamShake,
    NoHandCuf
}
public enum GameStates
{
    Bedroom,
    Trail,
    Justice,
    Peace,
    Freedom,
    Win,
    Pause,
    Resume
}



