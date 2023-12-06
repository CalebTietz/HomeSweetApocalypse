using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Main";
    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
