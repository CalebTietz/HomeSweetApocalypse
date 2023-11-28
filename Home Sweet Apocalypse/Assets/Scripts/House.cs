using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public float hitPoints = 3f;
    float currentHitPoints;
    // Update is called once per frame

    private void Start()
    {
        currentHitPoints = hitPoints;
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Zombie"))
        {
            Destroy(collidedWith);
            currentHitPoints = currentHitPoints - 1;
            Debug.Log(currentHitPoints);
        }
    }
}
