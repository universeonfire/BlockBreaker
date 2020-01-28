using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        //getting active scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        //loading next scene
        
        if (currentSceneIndex == lastSceneIndex) SceneManager.LoadScene(0);
        else SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
