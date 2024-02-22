using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameStates state;
   

    private void Awake()
    {
        Instance = this;
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
                break;
            case GameStates.Trail:
                SceneManager.LoadScene(2);
                break;
            case GameStates.Justice:
                SceneManager.LoadScene(3);
                break;
            case GameStates.Peace:
                SceneManager.LoadScene(5);
                break;
            case GameStates.Freedom:
                SceneManager.LoadScene(4);
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



