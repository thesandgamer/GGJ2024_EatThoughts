using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BodyManager : MonoBehaviour
{
    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject rightEye;

    private S_TongueManager tongue;

    [SerializeField] public Animator animator;

    private Plane plane = new Plane(Vector3.forward, 9);
    private void Awake()
    {
        tongue = FindObjectOfType<S_TongueManager>();
    }

    public Vector3 GetPosInWorld()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float distance))
        {
            return  ray.GetPoint(distance);
        }

        return Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 relativePos = GetPosInWorld() - leftEye.transform.position;
        Quaternion rot = Quaternion.LookRotation(relativePos, Vector3.up);
        leftEye.transform.rotation = rot;

        
        
        Vector3 relativePos2 = GetPosInWorld() - rightEye.transform.position;
        Quaternion rot2 = Quaternion.LookRotation(relativePos2, Vector3.up);
        
        rightEye.transform.rotation = rot2;
        
        
        
        //Quaternion.Euler()
        
    }

    public void MakeSadFace()
    {
        animator.SetTrigger("SadFace");
    }
    
    public void MakeHappyFace()
    {
        animator.SetTrigger("HappyFace");
    }
}
