using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static PauseGame Instance;
    [SerializeField] private GameObject pauseMenu;

    private GameManager gameState;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameState = GameManager.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }


    void TogglePauseMenu()
    {

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);

            if (pauseMenu.activeSelf)
            {
               // gameState.UpdateGameState(GameStates.Pause);
                Pause();
            }
            else
            {
               // gameState.UpdateGameState(GameStates.Resume);
                Resume();
            }
        }
    }

    public void Pause()
    {
        pauseMenu?.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu?.SetActive(false);
        Time.timeScale = 1f;
        
    }

}
