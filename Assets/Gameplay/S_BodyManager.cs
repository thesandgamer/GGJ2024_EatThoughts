using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BodyManager : MonoBehaviour
{
    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject rightEye;

    private S_TongueManager tongue;

    private Plane plane = new Plane(Vector3.forward, 1);
    private void Awake()
    {
        tongue = FindObjectOfType<S_TongueManager>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = tongue.GetPosInWorld() - leftEye.transform.position;
        Quaternion rot = Quaternion.LookRotation(relativePos, Vector3.up);
        leftEye.transform.rotation = rot;
    }
}
