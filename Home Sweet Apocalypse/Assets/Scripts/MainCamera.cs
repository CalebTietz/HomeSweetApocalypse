using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset = new Vector3(0,40,0);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate(){
        transform.position = Player.transform.position + offset;
    }
}
