using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Bounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.GetComponent<S_Element>().DestroyWhenOutOfScreen();
        }
    }
}
