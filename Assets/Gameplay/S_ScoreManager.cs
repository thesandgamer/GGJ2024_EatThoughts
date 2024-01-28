using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class S_ScoreManager : MonoBehaviour
{

    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private Image healthBar;
    [SerializeField] private RectTransform bar;

    private float finalScore = 0;

    private float MaxHapiness = 50;
    private float MinHapiness = -50;

    private S_Scoring scoring;

    private void Awake()
    {
        slider.maxValue = MaxHapiness;
        slider.minValue = MinHapiness;

        scoring = FindObjectOfType<S_Scoring>();
        
        UpdateUi();
    }

    private void OnEnable()
    {
        S_Mounth.Ev_GainScore += ChangeScore;
        S_BadThought.Ev_LooseScore += LooseScore;
    }

 

    private void OnDisable()
    {
        S_Mounth.Ev_GainScore -= ChangeScore;
        S_BadThought.Ev_LooseScore -= LooseScore;

    }

    private void ChangeScore(float arg1, float arg2)
    {
        finalScore += arg1;
        UpdateUi();
    }
    
    private void LooseScore(float obj)
    {
        finalScore += obj;
        UpdateUi();

    }

    public void UpdateUi()
    {
        if (scoring)
        {
            scoring.FinalScore = finalScore;
        }
        slider.value = finalScore;
        LeanTween.size(bar, bar.sizeDelta+ new Vector2(10f,10f) , .5f).setEase(LeanTweenType.easeShake);
        // healthBar.fillAmount = Mathf.Clamp(finalScore, MinHapiness, MaxHapiness);
    }
}
