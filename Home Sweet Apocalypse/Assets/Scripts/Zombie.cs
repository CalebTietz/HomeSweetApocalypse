using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    private static int NUM_ZOMBIE_TYPES = 3;
    /**
     * 
     * Normal Zombie   =   0
     * Speed Zombie    =   1
     * Brute Zombie    =   2
     * 
     */
    private static float TURN_COOLDOWN_DISTANCE = 2f; // how far a zombie must travel before zombie can turn again. Prevents double turning

    public int zombieType;

    private float speed;
    private float health;
    private Vector3 lastTurnPos;

    public GameObject POI;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        lastTurnPos = transform.position;

        // ensure zombieType is set to a valid type. Set to default type if not.
        if(zombieType < 0 || zombieType > NUM_ZOMBIE_TYPES - 1) { zombieType = 0; }

        // set stats for each zombie type
        switch (zombieType)
        {
            case 0: // normal
                speed = 3f;
                health = 100f;
                break;

            case 1: // speed
                speed = 6f;
                health = 75f;
                break;

            case 2: // brute
                speed = 1.5f;
                health = 225f;
                break;
        }

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Quaternion.Euler(0, -90, 0) * Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log((lastTurnPos - transform.position).magnitude);
        if ( (lastTurnPos - transform.position).magnitude <= TURN_COOLDOWN_DISTANCE) return;

        Debug.Log("test");

        if(other.gameObject.tag == "turnLeft")
        {
            transform.Rotate(0, -90, 0);
        }

        if(other.gameObject.tag == "turnRight")
        {
            transform.Rotate(0, 90, 0);
        }

        lastTurnPos = transform.position;
    }
}
