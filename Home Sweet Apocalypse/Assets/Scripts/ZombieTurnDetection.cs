using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTurnDetection : MonoBehaviour
{

    void Start()
    {
        Debug.Log("start");    
    }
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag == null) return;
        
        if (tag == "turnLeft")
        {
            gameObject.GetComponentInParent<Zombie>().turn("left");
        }

        if (tag == "turnRight")
        {
            gameObject.GetComponentInParent<Zombie>().turn("right");
        }
    }
}
