using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Arm : MonoBehaviour
{
    private Vector3 ScreenLocTarget;
    private Vector3 LocTargetWorld;

    private Vector3 StartPoint;
    
    
    private Plane plane = new Plane(Vector3.forward, 2);

    [SerializeField] private GameObject targetArm;
    [SerializeField] private GameObject arm;

    private bool armIsUp = false;
    
    [Header("Speed")]
    [SerializeField]
    private float armSpeed = 2;

    private float elapsedTime;
    
    
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            //targetArm.GetComponent<Rigidbody>().useGravity = false;
            targetArm.GetComponent<Rigidbody>().velocity = Vector3.zero;
            
                
            elapsedTime += Time.deltaTime;
            ScreenLocTarget = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(ScreenLocTarget);
            if (plane.Raycast(ray, out float distance))
            {
                LocTargetWorld = ray.GetPoint(distance);
            }               
    
            targetArm.GetComponent<Rigidbody>().MovePosition(LocTargetWorld);
    
           // Vector3 vel = new Vector3(armSpeed, armSpeed, armSpeed);
           // targetArm.transform.position = Vector3.SmoothDamp(targetArm.transform.position, LocTargetWorld, ref vel, 2);
           //targetArm.transform.position = LocTargetWorld;
           arm.transform.position = new Vector3(LocTargetWorld.x,arm.transform.position.y,LocTargetWorld.z);

        }

        if (Input.GetMouseButtonDown(1))
        {
            targetArm.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    
    
}
