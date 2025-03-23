using Kwabena.FinalCharacterController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private PlayerControls playerControls;
    private InputAction pauseMenu;

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private bool isPaused;

    void Awake()
    {
        playerControls = new PlayerControls();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        pauseMenu = playerControls.PauseMenu.Pause;
        pauseMenu.Enable();

        pauseMenu.performed += Pause;
    }

    private void OnDisable()
    {
        pauseMenu.Disable();
    }

    private void Pause(InputAction.CallbackContext context) 
    {
        isPaused = !isPaused;

        if (isPaused) 
        {
            ActivateMenu();
        }
        else 
        {
            DeactivateMenu();
        }
    }

    public void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
        isPaused = false;
    }

    public void MainMenuButton() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
