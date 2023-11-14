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
    private static int TURN_COOLDOWN_RESET_VAL = 200; // number of frames before zombie can turn again. Prevents double turning

    public int zombieType;

    private float speed;
    private float health;
    private int turnCooldown = 0;

    public GameObject POI;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // ensure zombieType is set to a valid type. Set to default type if not.
        if(zombieType < 0 || zombieType > NUM_ZOMBIE_TYPES - 1) { zombieType = 0; }

        // set stats for each zombie type
        switch (zombieType)
        {
            case 0: // normal
                speed = 1f;
                health = 100f;
                break;

            case 1: // speed
                speed = 2.5f;
                health = 75f;
                break;

            case 2: // brute
                speed = 0.75f;
                health = 225f;
                break;
        }

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.forward);
        transform.Translate(Quaternion.Euler(0, -90, 0) * Vector3.forward * Time.deltaTime * speed);
        if(turnCooldown > 0) { turnCooldown--; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(turnCooldown == 0 && other.gameObject.tag == "turnLeft")
        {
            transform.Rotate(0, -90, 0);
            turnCooldown = TURN_COOLDOWN_RESET_VAL;
        }

        if(turnCooldown == 0 && other.gameObject.tag == "turnRight")
        {
            transform.Rotate(0, 90, 0);
            turnCooldown = TURN_COOLDOWN_RESET_VAL;
        }
    }
}
