using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Restart : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private void Awake()
    {
        float score = FindObjectOfType<S_Scoring>().FinalScore;
        text.text = score.ToString();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
