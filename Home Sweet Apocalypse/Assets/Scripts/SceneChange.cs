using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void Start(){

    }
    public void MainGame(){
        ScoreKeeper.score=0;
        SceneManager.LoadScene("Main");
    }
    public void MainMenu(){
        ScoreKeeper.score=0;
        SceneManager.LoadScene("Main-Menu");
        //need a main menu scene, I think Luke Z was working on that
    }

}
