using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        StartCoroutine(LoadMainGame());
    }
    private IEnumerator LoadMainGame()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Swordfall");
        async.allowSceneActivation = false;
        while(!async.isDone)
        {
            if(async.progress >= 0.9f)
            {
                async.allowSceneActivation = true;
                Time.timeScale = 1f;
            }
            yield return null;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
