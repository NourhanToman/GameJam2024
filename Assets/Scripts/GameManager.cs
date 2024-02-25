using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum roomsRequirments
{
    book,
    portal,
    box
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameStates state;
    public GameObject PauseMenuPrefab;
    [HideInInspector] public int FreedomNoOfVisits = 0;
    [HideInInspector] public int PeaceNoOfVisits = 0;
    [HideInInspector] public int JusticeNoOfVisits = 0;
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
    }
    private void Update()
    {
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
                JusticeNoOfVisits++;
                SceneManager.LoadScene(3);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Peace:
                PauseMenuExists = false;
                PeaceNoOfVisits++;
                SceneManager.LoadScene(5);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Freedom:
                PauseMenuExists = false;
                FreedomNoOfVisits++;
                SceneManager.LoadScene(4);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Win:
                break;
            case GameStates.Pause:
                PauseMenuExists = true;
                Instantiate(PauseMenuPrefab);
                break;
            case GameStates.Resume:
                break;

        }
    }
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



