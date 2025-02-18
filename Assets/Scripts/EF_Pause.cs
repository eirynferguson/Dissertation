using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EF_Pause : MonoBehaviour
{
    public GameObject buttons;
    public GameObject pauseUI;
    public GameObject controlsButton;

    public static bool isPaused = false;
    public static bool controlsShown = false;

    // Start is called before the first frame update
    void Start()
    {
        controlsShown = false;
        isPaused = false;
        buttons.SetActive(false);
        controlsButton.SetActive(false);
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Time.timeScale = 1f;
                ResumeGame();
            }
            else
            {
                Time.timeScale = 0f;
                PauseGame();
                Debug.Log(Time.timeScale);
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("Paused");
        Cursor.lockState = CursorLockMode.None;

        buttons.SetActive(true);
        pauseUI.SetActive(true);
        isPaused = true;
 
        controlsButton.SetActive(false);
        controlsShown = false;
    }

    public void ResumeGame()
    {
        Debug.Log("Unpaused");
        Cursor.lockState = CursorLockMode.Locked;

        buttons.SetActive(false);
        pauseUI.SetActive(false);
        isPaused = false;
    }

    public void controls()
    {
        
        buttons.SetActive(false);
        pauseUI.SetActive(false);
        isPaused = true;

        controlsButton.SetActive(true);
        controlsShown = true;
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
