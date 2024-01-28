using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class S_TongueManager : MonoBehaviour
{
    private Vector3 ScreenLocTarget;
    private Vector3 LocTargetWorld;

    private Vector3 StartPoint;

    private Plane plane = new Plane(Vector3.forward, 2);

   [SerializeField] private GameObject tongueTarget;
   [SerializeField] private GameObject tongue;

    private bool TongueIsMoving = false;

    private bool TongueIsOut = false;

    [SerializeField] private S_BodyManager bodyManager;
    public static event Action  Ev_TongueReturn;

    [Header("Speed")]
    [SerializeField]
    private float tongueSpeed = 2;
    [SerializeField]
    private float tongueReturnSpeed = 2;

    private void Awake()
    {
        tongueTarget.transform.position = transform.position;
        StartPoint = transform.position;

        HideTongue();
    }

    private void Start()
    {
        bodyManager = FindObjectOfType<S_BodyManager>();

    }


    public Vector3 GetPosInWorld()
    {
        ScreenLocTarget = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(ScreenLocTarget);

        if (plane.Raycast(ray, out float distance))
        {
            return  ray.GetPoint(distance);
        }

        return Vector3.zero;

    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!TongueIsMoving)
            {
                TongueIsMoving = true;
                LocTargetWorld = GetPosInWorld();
  
                ShowTongue();

                MoveTongueToTarget();
            }
   
        }
        
    }
    public void MoveTongueToTarget()
    {
        LeanTween.move(tongueTarget, LocTargetWorld, tongueSpeed).setOnComplete(TongueReachTarget);
        FindObjectOfType<S_Mounth>().CanEat = false;


    }

    public void ReturnTongue()
    {
        LeanTween.move(tongueTarget,StartPoint , tongueReturnSpeed).setOnComplete(TongueReturned);
        FindObjectOfType<S_Mounth>().CanEat = true;
    }
    

    public void TongueReachTarget()
    {
        ReturnTongue();
    }

    public void TongueReturned()
    {
        HideTongue();
        Ev_TongueReturn?.Invoke();
        FindObjectOfType<S_Mounth>().CanEat = false;

       // Invoke("Retun",2.6f);

    }

    public void Retun()
    {
        TongueIsMoving = false;
    }

    public void HideTongue()
    {
        tongue.SetActive(false);

    }

    public void ShowTongue()
    {
        tongue.SetActive(true);
        bodyManager.animator.SetTrigger("TongueOut");
    }

 
}



