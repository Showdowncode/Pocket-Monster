using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Setter tiden til 0 for å stanse spillet.
        pauseMenu.SetActive(true); // Aktiver pausemenyen.
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Gjenopptar normal spilltid.
        pauseMenu.SetActive(false); // Deaktiverer pausemenyen.
    }
}