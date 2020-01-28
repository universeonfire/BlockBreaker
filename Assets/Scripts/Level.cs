using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // serialized for debugging purposes doesnt need to otherwise

    //Cached Reference
    private SceneLoader sceneLoader;
    private GameStatus gameStatus;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        gameStatus.AddToScore();
        if (breakableBlocks == 0) sceneLoader.LoadNextScene();
    }
}
