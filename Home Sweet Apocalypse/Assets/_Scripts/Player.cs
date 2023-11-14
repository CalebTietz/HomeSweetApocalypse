using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){
            this.gameObject.transform.position += transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.S)){
            this.gameObject.transform.position += transform.forward * Time.deltaTime * -speed;
        }

        if (Input.GetKey(KeyCode.A)){
            this.gameObject.transform.position += transform.right * Time.deltaTime * -speed;
        }

        if (Input.GetKey(KeyCode.D)){
            this.gameObject.transform.position += transform.right * Time.deltaTime * speed;
        }




        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.LookAt(mouseScreenPosition);


    }
}
