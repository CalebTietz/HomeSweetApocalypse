using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance;

    [Header("Inscribed")]
    public static int score = 0;
    public static int highScore=0;

    void Awake(){
        if(instance ==null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score);
        if(score>highScore){
            highScore=score;
        }
    }
}
