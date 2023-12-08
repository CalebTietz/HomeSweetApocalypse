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

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Store the current position
        Vector3 pos = transform.position;

        // Calculate the movement direction based on user input
        Vector3 moveDirection = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            moveDirection.z = 1;
        }
        if(Input.GetKey(KeyCode.S))
        {
            moveDirection.z = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -1;
        }

        moveDirection = moveDirection.normalized;

        // Check if the move direction is not zero (user is trying to move)
        if (moveDirection.magnitude > 0.1f)
        {
            // Calculate the target position
            Vector3 targetPos = pos + moveDirection * speed * Time.deltaTime;

            // Perform a raycast to check for collisions before moving
            RaycastHit hit;
            if (!Physics.Raycast(pos, moveDirection, out hit, speed * Time.deltaTime))
            {
                // No collision, update the position
                transform.position = targetPos;
            }
            /*else
            {
                // There's a collision, adjust the position to the point of collision
                transform.position = hit.point - moveDirection * 0.1f; // Adjust the offset if needed
            }*/
        }
        rb.velocity = new Vector3(0, rb.velocity.y, 0);


        Vector3 v3 = Input.mousePosition;
        v3.z=40;
       // v3 = Camera.main.ScreenToWorldPoint(v3);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(v3);
        mousePos.y =1.5f;

        // Code to make a point for player to look at in between itself and mouse. Makes shooting easier
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude * .5f;
       
        //transform.LookAt(mouseRay.origin + mouseRay.direction * midPoint);

        Vector3 temp = mouseRay.origin + mouseRay.direction * midPoint ;
        //because the mouse is at y=40 due, manually set it to 1.5
        temp.y = 1.5f;
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
