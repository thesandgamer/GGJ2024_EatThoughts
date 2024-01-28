using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Pop", Random.Range(0,1.5f));
    }


    private void Pop()
    {
        FindObjectOfType<Scr_FeedbacksManager>().PopUpUi(gameObject);

    }

    
    
    
}
