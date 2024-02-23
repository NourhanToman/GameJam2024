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
        state = GameStates.Bedroom;
        
    }
   public void UpdateGameState(GameStates states)
    {
        state = states;

        switch (state)
        {
            case GameStates.Bedroom:
                SceneManager.LoadScene(1);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Trail:
                SceneManager.LoadScene(2);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Justice:
                SceneManager.LoadScene(3);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Peace:
                SceneManager.LoadScene(5);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Freedom:
                SceneManager.LoadScene(4);
                TextManger.instance._player = Camera.main.gameObject;
                break;
            case GameStates.Win:
                break;
            case GameStates.Pause:
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



