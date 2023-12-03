using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 5;
    public float speed = 50;
    private Rigidbody rb;

    void Start(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.y=2;
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 direction = (transform.position-mousePos);
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
    }
}
