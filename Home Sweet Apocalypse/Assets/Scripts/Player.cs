using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{

    [Header("Inscribed")]
    public float speed = 15f;
    public GameObject bulletPrefab;
    public GameObject debugPrefab;
    public bool canFire = true;
    public float timer = 0;

    [Header("Dynamic")]

    public float shotDelay = .3f;
    public GameObject bullet;
    public GameObject launchPoint;
    public Vector3 launchPos;
    public float bulletSpeed = 20;

    // Update is called once per frame
    void Update()
    {
        //moves player with WASD keys.
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


        Vector3 v3 = Input.mousePosition;
        v3.z=40;
       // v3 = Camera.main.ScreenToWorldPoint(v3);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(v3);
        mousePos.y =2.5f;

        // Code to make a point for player to look at in between itself and mouse. Makes shooting easier
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude * .5f;
       
        //transform.LookAt(mouseRay.origin + mouseRay.direction * midPoint);

        Vector3 temp = mouseRay.origin + mouseRay.direction * midPoint ;
        //because the mouse is at y=40 due, manually set it to 2
        temp.y = 2f;
        transform.LookAt(mousePos);

        //sets rate of fire for gun
        if(canFire !=true){
            timer += Time.deltaTime;
            if(timer>shotDelay){
                canFire = true;
                timer=0;
            }
        }

        if(canFire == true){
            if(Input.GetMouseButton(0)){
                canFire = false;
                
                launchPoint.SetActive(true);
                Transform launchPointTrans = transform.Find("LaunchPoint");
                launchPoint = launchPointTrans.gameObject;
                launchPos = launchPointTrans.position;

                bullet = Instantiate(bulletPrefab) as GameObject;
                

                bullet.transform.position = launchPos;
                bullet.transform.LookAt(temp);
            }
        }
        
    }
}
