using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        if (sceneName == "")
        {
            Debug.LogError("Scene name is not set in LoadNextScene script");
        }

        JUCEInitializer.JUCEInitialised += LoadScene;
    }
    
    public void LoadScene()
    {
        UnityEngine.Debug.Log("LoadNextScene: Loading scene: " + sceneName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
