using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class S_Element : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    [SerializeField] private AnimationCurve spawnCurve;


    public float GainScore = 0;
    
    private void Awake()
    {
        this.gameObject.transform.localScale = Vector3.zero;
        Appear();

        Vector3 randomForce = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        GetComponent<Rigidbody>().AddForce(randomForce);
    }

    private void Appear()
    {
        LeanTween.scale(this.gameObject, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutBack);
    }
    
    
    //Quand touche la langue
    private void OnCollisionEnter(Collision other)
    {
        print("Collide1");

        if (other.gameObject.layer == 7)
        {
            print("Collide");
            transform.parent = other.transform;
            
        }
        else
        {
            foreach (ContactPoint contact in other.contacts)
            {
                GetComponent<Rigidbody>().AddForce(contact.normal * 10);
                print("Punch");
                break;
            }
        }
    }

    public void DestroyWhenOutOfScreen()
    {
        Destroy();
    }
    
    public void BeingEat()
    {
        Destroy();
    }

    public void Desapear()
    {
        LeanTween.scale(this.gameObject, Vector3.zero, 0.5f).setEase(LeanTweenType.punch).setOnComplete(Destroy);
        //Play vfx/sfx
    }

    private void Destroy()
    {
        Destroy(gameObject);

    }



}
