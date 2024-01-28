using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TongueCollide : MonoBehaviour
{

   public bool Activated;


   private void OnTriggerEnter(Collider other)
   {

      if (other.gameObject.layer == 8)
      {
         print("Stick On ");
         other.GetComponent<Rigidbody>().useGravity = false;
         other.GetComponent<Rigidbody>().velocity = Vector3.zero;

        // other.GetComponent<BoxCollider>().isTrigger = true;
         //other.GetComponent<BoxCollider>().enabled = false;

         
         other.transform.parent = transform;

       //  other.GetComponent<S_Element>().enabled = false;

      }
   }
}
