using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class S_ScoreManager : MonoBehaviour
{

    [SerializeField] private UnityEngine.UI.Slider slider;

    private float finalScore = 0;

    private float MaxHapiness = 50;
    private float MinHapiness = -50;

    private void Awake()
    {
        slider.maxValue = MaxHapiness;
        slider.minValue = MinHapiness;
    }

    private void OnEnable()
    {
        S_Mounth.Ev_GainScore += ChangeScore;
    }
    private void OnDisable()
    {
        S_Mounth.Ev_GainScore -= ChangeScore;
    }

    private void ChangeScore(float arg1, float arg2)
    {
        finalScore += arg1;
        UpdateUi();
    }

    public void UpdateUi()
    {
        slider.value = finalScore;
    }
}
