using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{

    [Header("Inscribed")]
    public float speed = 15f;
    public GameObject bulletPrefab;

    [Header("Dynamic")]


    public GameObject bullet;
    public GameObject launchPoint;
    public Vector3 launchPos;
    public float bulletSpeed = 20;

    private float lastShotTime;
    private float shootInterval;

    // Start is called before the first frame update

    void Awake(){

        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;

        launchPoint.SetActive(false);
        lastShotTime = 0f;
        shootInterval = 0.1f;
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
        
        if(Input.GetMouseButton(0)){

            if (lastShotTime == 0f || lastShotTime + shootInterval < Time.time)
            {
                lastShotTime = Time.time;

                launchPoint.SetActive(true);
                Transform launchPointTrans = transform.Find("LaunchPoint");
                launchPoint = launchPointTrans.gameObject;
                launchPos = launchPointTrans.position;

                bullet = Instantiate(bulletPrefab) as GameObject;
                bullet.transform.position = launchPos;
                
                Vector3 direction = new Vector3(temp.x, temp.y, temp.z);
                bullet.GetComponent<Rigidbody>().velocity += bulletSpeed *direction;

                //bullet.transform.LookAt(temp);
                //bullet.GetComponent<Rigidbody>().isKinematic = true;
            }
            
        
        }
        
    }
}
