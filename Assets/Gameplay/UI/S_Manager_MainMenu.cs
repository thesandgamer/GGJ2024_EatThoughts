using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class S_Manager_MainMenu : MonoBehaviour
{
    
    [SerializeField]
    private GameObject canvas;
    

    public UnityEngine.UI.Button playButton;

    public static event Action Ev_MainMenuDisapear ;

    [SerializeField] 
    private SceneAsset sceneToUnload;

    public void RemoveUi()
    {
        LeanTween.moveX(canvas,150, 2).setEase(LeanTweenType.easeInCubic).setOnComplete(RemoveMainMenu);
        playButton.interactable = false;
    }

    public void RemoveMainMenu()
    {
        //SceneManager.UnloadSceneAsync( SceneManager.GetSceneByName("MainMenu"));
        SceneManager.UnloadSceneAsync( sceneToUnload.name);
        OnEvMainMenuDisapear();
    }

    private static void OnEvMainMenuDisapear()
    {
        Ev_MainMenuDisapear?.Invoke();
    }
}
