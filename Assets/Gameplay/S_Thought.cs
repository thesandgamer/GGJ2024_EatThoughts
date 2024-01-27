using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class S_Thought : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;

    public List<String> phrases = new List<string>();

    private void Awake()
    {
        
        text.text = phrases[Random.Range(0,phrases.Count)];
    }
}
