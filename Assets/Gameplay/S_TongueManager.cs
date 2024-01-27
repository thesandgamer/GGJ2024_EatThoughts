using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TongueManager : MonoBehaviour
{
    private Vector3 ScreenLocTarget;
    private Vector3 LocTargetWorld;

    private Vector3 StartPoint;

    private Plane plane = new Plane(Vector3.forward, 2);

    [SerializeField] private GameObject tongue;

    private bool TongueIsMoving = false;
    
    public static event Action  Ev_TongueReturn;

    [Header("Speed")]
    [SerializeField]
    private float tongueSpeed = 2;
    [SerializeField]
    private float tongueReturnSpeed = 2;

    private void Awake()
    {
        tongue.transform.position = transform.position;
        StartPoint = transform.position;
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
                /*
                ScreenLocTarget = Input.mousePosition;

                Ray ray = Camera.main.ScreenPointToRay(ScreenLocTarget);

                if (plane.Raycast(ray, out float distance))
                {
                    LocTargetWorld = ray.GetPoint(distance);
                }*/

                MoveTongueToTarget();
            }
   
        }
        
    }
    public void MoveTongueToTarget()
    {
        LeanTween.move(tongue, LocTargetWorld, tongueSpeed).setOnComplete(TongueReachTarget);

    }

    public void ReturnTongue()
    {
        LeanTween.move(tongue,StartPoint , tongueReturnSpeed).setOnComplete(TongueReturned);
    }
    

    public void TongueReachTarget()
    {
        ReturnTongue();
    }

    public void TongueReturned()
    {
        TongueIsMoving = false;
        Ev_TongueReturn?.Invoke();

    }

    public void HideTongue()
    {
        
    }

 
}



