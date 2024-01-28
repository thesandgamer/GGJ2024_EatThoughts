using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Faire un affichage custom pour le temps: Minutes:Segondes (custom GUI)
[Serializable]
public struct TimeFormat
{
   [SerializeField] public float min;
   [SerializeField] [Range(0, 59)]public float seg;
}
public class Scr_TimerManager : MonoBehaviour
{
    public static event Action timerFinished;


    [Header("Timer")]
    [SerializeField] private GameObject panelTimer;

    [SerializeField] private TMP_Text minText;
    [SerializeField] private TMP_Text secText;

    public TimeFormat startTime;
    




    private float totalTime = 0f;
    private float levelTime;
    public float TotalTime{ get { return levelTime;}}

    public float FinalTime{ get { return totalTime;}}


    private bool timerIsRunning = false;
    
    private IEnumerator coroutine;
    private IEnumerator goCoroutine;

    [SerializeField] Scr_FeedbacksManager fb;


    private void Start()
    {

        fb = FindObjectOfType<Scr_FeedbacksManager>();
        
        coroutine = TimerIsRunning();
        
        totalTime = startTime.min * 60 + startTime.seg;
        levelTime = totalTime;
        
        panelTimer.SetActive(true);
        DisplayTimer();

        fb.PopUpTimer(panelTimer);
        Invoke("StartTimer",1);

    }    

    public void StartTimer()
    {
        StartCoroutine(coroutine);
        enabled = true;
    }

    bool reachNearEnd = false;
    IEnumerator TimerIsRunning()
    {
        //Peut être éviter de faire ça
        while (true)
        {
            if (!reachNearEnd&& totalTime <= 4)
            {
                reachNearEnd = true;
                TimerNearEnd();
            }
            if (totalTime > 0)
            {
                DisplayTimer();
                totalTime -= Time.deltaTime;
            }
            else
            {
                totalTime = 0;
                EndOfTimer();
                if (timerFinished != null) timerFinished();
            }
           
            
            yield return null;
        }
        yield return null;

    }
    
    private void EndOfTimer()
    {
        StopCoroutine(coroutine);
        print("Stopped timer at " + Time.time);
        Destroy(panelTimer);
        //Rajouter un FX du timer qui disparait
    }
    


    void DisplayTimer()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60);
        int secondes = Mathf.FloorToInt(totalTime % 60);
        minText.text = minutes.ToString("00");
        secText.text = secondes.ToString("00");
       // secText.text = string.Format("{0:00}:{1:00}",minutes, secondes);
        
    }

    void TimerNearEnd()
    {
        fb.TimerNearEndFb(panelTimer);
        print("Timer near end");
        //Le timer va size up and down avec un peut de tremblement(peut être légère rotation)
        //Il va aussi aléterner entre rouge et couleur de base
    }
    
    
}
