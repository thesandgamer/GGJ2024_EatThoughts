using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Pill : MonoBehaviour
{
    [SerializeField] private float MaxValue = 10;
    [SerializeField] private float MinValue = -10;
    
    void Start()
    {
        GetComponent<S_Element>().GainScore = (int)Random.Range(MinValue, MaxValue);
        
    }   
    
}
