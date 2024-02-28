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
        pauseMenu?.SetActive(false);
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
            pauseMenu?.SetActive(!pauseMenu.activeSelf);

            if (pauseMenu.activeSelf)
            {

                Pause();
                
            }
            else
            {

                Resume();
                
            }
        }
    }

    public void Pause()
    {
        GameManager.Instance.playerInputs.cursorLocked = false;
        GameManager.Instance.cameraLock.LockCameraPosition = true;
        //AudioManager.instance.PauseAll();
        pauseMenu?.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        GameManager.Instance.playerInputs.cursorLocked = true;
        GameManager.Instance.cameraLock.LockCameraPosition = false;
        //AudioManager.instance.ResumeAll();
        pauseMenu?.SetActive(false);
        Time.timeScale = 1f;

    }


    /*  public static PauseGame Instance;
      [SerializeField] private GameObject pauseMenuPrefab; // Prefab to instantiate

      private GameObject pauseMenuInstance; // Reference to the instantiated pause menu
      private GameManager gameState;

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
          if (pauseMenuInstance == null)
          {
              // Instantiate the pause menu prefab
              pauseMenuInstance = Instantiate(pauseMenuPrefab, transform.position, transform.rotation);
              pauseMenuInstance.transform.SetParent(transform); // Set the PauseGame object as the parent
          }

          if (pauseMenuInstance.activeSelf)
          {
              Pause();
              GameManager.Instance.playerInputs.cursorLocked = false;
              GameManager.Instance.cameraLock.LockCameraPosition = true;
          }
          else
          {
              Resume();
              GameManager.Instance.playerInputs.cursorLocked = true;
              GameManager.Instance.cameraLock.LockCameraPosition = false;
          }
      }

      public void Pause()
      {
          pauseMenuInstance?.SetActive(true);
          Time.timeScale = 0f;
      }

      public void Resume()
      {
          if (pauseMenuInstance != null)
          {
              Destroy(pauseMenuInstance);
              pauseMenuInstance = null;
          }

          Time.timeScale = 1f;
      }*/

}
