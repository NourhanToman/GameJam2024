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
    public PlayerState playerState;
    [HideInInspector] public GameObject Player;
    [HideInInspector] public StarterAssetsInputs playerInputs;
    [HideInInspector] public CustomThirdPersonController cameraLock;
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
        requirments = roomsRequirments.book;
        playerState = PlayerState.NotFree;
        cameraLock = Player.GetComponent<CustomThirdPersonController>();
    }
    public void UpdateGameState(GameStates states)
    {
        state = states;

        switch (state)
        {
            case GameStates.Bedroom:
                SceneController.instance.NextScene(1);
                TextManger.instance._player = Camera.main.gameObject;
                Player = GameObject.FindWithTag("Player");
                cameraLock = Player.GetComponent<CustomThirdPersonController>();
                playerInputs = Player.GetComponent<StarterAssetsInputs>();
                break;
            case GameStates.Trail:
                SceneController.instance.NextScene(2);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Justice:
                SceneController.instance.NextScene(3);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Peace:
                SceneController.instance.NextScene(5);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Freedom:
                SceneController.instance.NextScene(4);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Win:
                SceneController.instance.NextScene(1);
                TextManger.instance._player = Camera.main.gameObject;
                break;
           /* case GameStates.MainMenu:
                Destroy(gameObject);
                break;*/
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
    MainMenu,
    Bedroom,
    Trail,
    Justice,
    Peace,
    Freedom,
    Win
   
}



