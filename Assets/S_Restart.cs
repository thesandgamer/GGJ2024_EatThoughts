using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Restart : MonoBehaviour
{
    public void GameRestart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
