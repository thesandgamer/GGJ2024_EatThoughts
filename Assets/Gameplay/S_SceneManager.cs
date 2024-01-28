using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneManager : MonoBehaviour
{
    private List<AsyncOperation> baseSceneToLoad = new List<AsyncOperation>();

    private void OnEnable()
    {
        Scr_TimerManager.timerFinished += FinishGame;
    }
    private void OnDisable()
    {
        Scr_TimerManager.timerFinished -= FinishGame;
    }


    private void Start()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("SceneAsset", LoadSceneMode.Additive);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
    }

    void FinishGame()
    {
        SceneManager.UnloadSceneAsync("GameScene");
        if (FindObjectOfType<S_Scoring>().FinalScore > 0)
        {
            LoadGoodEnding();

        }
        else
        {
            LoadBadEnding();
        }

    }

    void LoadBadEnding()
    {
        SceneManager.LoadSceneAsync("End_Bad", LoadSceneMode.Additive);

    }
    void LoadGoodEnding()
    {
        SceneManager.LoadSceneAsync("End_Good", LoadSceneMode.Additive);
    }
}
