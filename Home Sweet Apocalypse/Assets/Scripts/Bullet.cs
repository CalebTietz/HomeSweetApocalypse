using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject debugPrefab;
    public int damage = 25;
    public float speed = 50;
    private Rigidbody rb;

    void Start(){
        Vector3 v3 = Input.mousePosition;
        v3.z=40;
       // v3 = Camera.main.ScreenToWorldPoint(v3);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(v3);
        mousePos.y =2;
        
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 direction = (mousePos-transform.position);
        direction.y=2;

        //Debug code used to find error where screenToWorldPoint would not update z value correctly
        /*
        GameObject debug = Instantiate(debugPrefab) as GameObject;
        debug.transform.position = direction;
        
        GameObject debug = Instantiate(debugPrefab) as GameObject;
        debug.transform.position = mousePos;
        debug.GetComponent<Renderer>().material.color=Color.red;

        debug = Instantiate(debugPrefab) as GameObject;
        debug.transform.position = transform.position;
        */
        
        rb.velocity = new Vector3(direction.x, direction.y, direction.z).normalized * speed;

    }


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
            collidedWith.GetComponent<Zombie>().loseHealth(damage);
            Destroy(gameObject);

        }
        if (collidedWith.CompareTag("House"))
        {
            Destroy(gameObject);

        }
    }
}
