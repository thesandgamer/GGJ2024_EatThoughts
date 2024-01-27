using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BadThought : MonoBehaviour
{
    public static event Action<float> Ev_LooseScore;

    [SerializeField] private float timeToAbsorb = 5;
    private void Start()
    {
        Invoke("Absorb", timeToAbsorb);
    }

    private void Absorb()
    {
        if (GetComponent<S_Element>())
        {
            Ev_LooseScore?.Invoke(GetComponent<S_Element>().GainScore);
        }
        GetComponent<S_Element>().Desapear();
        
    }
}
