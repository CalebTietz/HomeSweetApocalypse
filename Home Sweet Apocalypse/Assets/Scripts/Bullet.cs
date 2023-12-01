using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public int damage;
    public float xLimit = 10;
    public float yLimit = 10;

    private Rigidbody rb;


    // Update is called once per frame
    void Update()
    {
        /*checks for bounds to be deleted. I tried to make variables to
        be able to replace bounds dynamically while testing, but it didnt work well.
        */
        Vector3 pos = transform.position;
        if(pos.x>100 || pos.x<-100){
            Destroy(gameObject);
        }
        if(pos.y>100 || pos.y<-100){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        //if youd collide with a zombie the bullet is destroyed and the zombie is damaged
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Zombie"))
        {
            Destroy(gameObject);

        }
    }

    void FixedUpdate()
    {
        //rb.velocity = Vector3.forward * speed * Time.deltaTime;
    }
}
