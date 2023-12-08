using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{


    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Zombie"))
        {

            Camera.main.GetComponent<Wave>().zombieDied();
            Destroy(collidedWith);
            

            HealthBar bar =GameObject.Find("Health Bar").GetComponent<HealthBar>();
            bar.loseHealth();

            
        }
    }
}
