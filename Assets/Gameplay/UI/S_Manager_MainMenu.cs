using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Manager_MainMenu : MonoBehaviour
{
    
    [SerializeField]
    private GameObject canvas;

    [SerializeField] 
    private Scene sceneToUnload;

    public void RemoveUi()
    {
        LeanTween.moveX(canvas,150, 2).setEase(LeanTweenType.easeInCubic).setOnComplete(RemoveMainMenu);
    }

    public void RemoveMainMenu()
    {
        SceneManager.UnloadSceneAsync( SceneManager.GetSceneByName("MainMenu"));
    }
    
}
