using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Element : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private void OnCollisionEnter(Collision other)
    {
        print("Collide1");

        if (other.gameObject.layer == 7)
        {
            print("Collide");
            foreach (ContactPoint contact in other.contacts)
            {
                transform.parent = other.transform;
                break;
            }
        }
    }



}
