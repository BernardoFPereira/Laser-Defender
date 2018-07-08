using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadScene(string name)
    {
        Debug.Log("New scene Load: " + name);
        SceneManager.LoadScene(name);
    }

    public void LoadNextScene()
    {
        Debug.Log("Next scene loaded.");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        print("Quit requested");
        Application.Quit();
    }
    public void BrickDestroyed()
    {
        LoadNextScene();
    }
}