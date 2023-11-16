using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;


        if (Input.GetKey(KeyCode.W)){
            pos.z += speed*Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)){
            pos.z -= speed*Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)){
            pos.x -= speed*Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)){
            pos.x += speed*Time.deltaTime;
        }

        transform.position = pos;


        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude * .5f;
        //transform.LookAt(mouseRay.origin + mouseRay.direction * midPoint);

        Vector3 temp = mouseRay.origin + mouseRay.direction * midPoint;
        temp.y = 2;
        transform.LookAt(temp);
        
    }
}
