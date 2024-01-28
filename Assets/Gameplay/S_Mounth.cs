using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Mounth : MonoBehaviour
{
  private List<float> tempScore = new List<float>();

  public static event Action<float,float> Ev_GainScore;

  public bool CanEat = false;

  private S_BodyManager bodyManager;

  private void Start()
  {
    bodyManager = FindObjectOfType<S_BodyManager>();

  }

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
    if (CanEat)
    {
      if (other.gameObject.layer == 8)
      {
        print("Dest");

        EatElement(other.gameObject);
      }
    }

  }

  void EatElement(GameObject other)
  {
    tempScore.Add(other.GetComponent<S_Element>().GainScore);
    other.GetComponent<S_Element>().BeingEat();
    
  }


  void CalculateScore()
  {
    foreach (Transform child in transform.GetComponentInChildren<Transform>())
    {
      if (child.gameObject.GetComponent<S_Element>())
      {
        tempScore.Add(child.GetComponent<S_Element>().GainScore);
        child.gameObject.GetComponent<S_Element>().BeingEat();
      }
    }
    
    bodyManager.animator.SetTrigger("Chew");
    float score = 0;
    foreach (var val in tempScore)
    {
      score += val;
    }

    if (score != 0)
    {
      Reaction(score > 0);
    }
    else
    {
      bodyManager.animator.SetTrigger("FinishChew");
      Invoke("RestetTongue",1.5f);

    }
    
    OnEvGainScore(score,tempScore.Count);
    tempScore.Clear();
    print("Calculate score ");

  }
  

  private void Reaction(bool isGood)
  {
    if (isGood)
    {
      bodyManager.animator.SetTrigger("GoodReaction");
      FindObjectOfType<Scr_AudioManager>().Play("GoodChew");
      Invoke("RestetTongue",2.6f);

    }
    else
    {
      bodyManager.animator.SetTrigger("BadReaction");
      FindObjectOfType<Scr_AudioManager>().Play("BadChew");
      Invoke("RestetTongue",2.6f);
    }
  }

  private static void OnEvGainScore(float score, float multiplier )
  {
    Ev_GainScore?.Invoke(score,multiplier);
  }

  private void RestetTongue()
  {
    FindObjectOfType<S_TongueManager>().Retun();
  }
  
}
