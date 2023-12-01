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
        if (zombieType < 0 || zombieType > NUM_ZOMBIE_TYPES - 1) { zombieType = 0; }

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

    // turn the zombie in specified direction: left or right, by 90 degrees
    public void turn(string direction)
    {
        if ((lastTurnPos - transform.position).magnitude <= TURN_COOLDOWN_DISTANCE) return;

        Debug.Log("test");

        if (direction == "left")
        {
            transform.Rotate(0, -90, 0);
        }
        
        if (direction == "right")
        {
            transform.Rotate(0, 90, 0);
        }

        lastTurnPos = transform.position;
    }

    public void loseHealth(int damage)
    {
        StartCoroutine(blinkRed());

        health -= damage;
        if (health <= 0) { Destroy(gameObject); }
    }

    private IEnumerator blinkRed()
    {
        Material[] mats = getAllMaterials();
        Color[] originalColors = new Color[mats.Length];

        // get original colors
        for (int i = 0; i < mats.Length; i++)
        {
            originalColors[i] = mats[i].color;
        }

        // set gameObject to red
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].color = Color.red;
        }

        // wait a few frames
        yield return new WaitForSeconds(0.1f);

        // restore gameObject's original colors
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].color = originalColors[i];
        }
    }

    private Material[] getAllMaterials()
    {
        Renderer[] rend = GetComponentsInChildren<Renderer>();

        Material[] mats = new Material[rend.Length];
        for (int i = 0; i < rend.Length; i++)
        {
            mats[i] = rend[i].material;
        }

        return mats;
    }


        private void OnCollisionEnter(Collision coll)
    {
        //if youd collide with a zombie the bullet is destroyed and the zombie is damaged
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Bullet"))
        {
            loseHealth(5);
        }
    }

}
