using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadSceneAsync("ReaLevel 1");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
