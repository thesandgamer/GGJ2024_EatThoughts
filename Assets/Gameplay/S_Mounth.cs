using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Mounth : MonoBehaviour
{
  private List<float> tempScore = new List<float>();

  public static event Action<float,float> Ev_GainScore;

  private void OnEnable()
  {
    S_TongueManager.Ev_TongueReturn += CalculateScore;
  }
  private void OnDisable()
  {
    S_TongueManager.Ev_TongueReturn -= CalculateScore;
  }

  private void OnTriggerEnter(Collider other)
  {

    if (other.gameObject.layer == 8)
    {
      print("Dest");

      EatElement(other.gameObject);
    }
  }

  private void OnCollisionEnter(Collision other)
  {
    print("Dest");
  }

  void EatElement(GameObject other)
  {
    tempScore.Add(other.GetComponent<S_Element>().GainScore);
    other.GetComponent<S_Element>().BeingEat();
    
  }


  void CalculateScore()
  {
    float score = 0;
    foreach (var val in tempScore)
    {
      score += val;
    }
    OnEvGainScore(score,tempScore.Count);
    tempScore.Clear();
    print("Calculate score ");

  }

  private static void OnEvGainScore(float score, float multiplier )
  {
    Ev_GainScore?.Invoke(score,multiplier);
  }
  
  
}
