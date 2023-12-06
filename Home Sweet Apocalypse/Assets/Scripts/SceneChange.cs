using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void Start(){

    }
    public void LukeMain(){
        SceneManager.LoadScene("LukeMain");
    }
    public void MainMenu(){
        //SceneManager.LoadScene();
        //need a main menu scene, I think Luke Z was working on that
    }

}
