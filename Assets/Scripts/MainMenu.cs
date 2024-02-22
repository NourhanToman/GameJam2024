using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   /* [SerializeField] private GameObject loaderUI;
    [SerializeField] private Slider progressSlider;

    public void LoadScene(int index)
    {
        StartCoroutine(_LoadScene(index));
    }
 
    public void mainMenu()
    {
        StartCoroutine(_LoadScene(0));
    }*/

    public void Quit() { 
    Application.Quit();
    }

   /* public void mainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public IEnumerator _LoadScene(int index)
    {
        progressSlider.value = 0;
        loaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;

        float progress = 0;

        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;

            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }*/
}
