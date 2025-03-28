using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class EF_Interactables : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    public GameObject question;
    public GameObject sceneChange;

    public GameObject infoSheet;
    public GameObject questionUI;
    public GameObject twoquestionUI;
    public GameObject nextLevel;

    public string itemName;

    EF_PlayerController playerScript;
    EF_Pause pauseScript;
    EF_QuestionScript questionScript;
    EF_SceneChanger changeScene;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerScript = player.GetComponent<EF_PlayerController>();
        }

        itemName = gameObject.name;
        gameObject.layer = LayerMask.NameToLayer("Interactable");

        pauseScript = canvas.GetComponent<EF_Pause>(); //call pause script to check pause state
        questionScript = question.GetComponent<EF_QuestionScript>(); //call question script to get points
        changeScene = sceneChange.GetComponent<EF_SceneChanger>();
    }

    /*public void RemoveObject()
    {
        this.gameObject.SetActive(false);
    }*/

    void OnInteract()
    {
        Debug.Log("Interacted");

        if (pauseScript.isPaused == false) //prevents other UI showing ontop of pause menu 
        {
            if (itemName == "Paper")
            {
                infoPaper(itemName);
            }
            else if (itemName == "Question 1")
            {
                questionSheet(itemName);
            }
            else if (itemName == "Next Level")
            {
                loadNextLevel(itemName);
            }
            else if (itemName == "Question 2")
            {
                questionSheet2(itemName);
            }
        }
    }

    void infoPaper(string item)
    {
        Debug.Log("Info Sheet");

        Cursor.lockState = CursorLockMode.None;
        infoSheet.SetActive(true);
        Time.timeScale = 0f;
    }

    void questionSheet(string item)
    {
        Debug.Log("Question");

        Cursor.lockState = CursorLockMode.None;
        questionUI.SetActive(true);
        twoquestionUI.SetActive(false);
        Time.timeScale = 0f;
    }

    void questionSheet2(string item)
    {
        Debug.Log("Question 2");

        Cursor.lockState = CursorLockMode.None;
        questionUI.SetActive(false);
        twoquestionUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void loadNextLevel(string item)
    {
        if (questionScript.points == 5)
        {
            Debug.Log("Next Level");
            changeScene.ChangeScene("SceneTwo");
        }
    }

    public void back()
    {
        if (pauseScript.isPaused == false)  //if not paused lock mouse and resume
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        else  //if pause menu behind UI keep mouse moving and background paused
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        infoSheet.SetActive(false);
        questionUI.SetActive(false);
        twoquestionUI.SetActive(false);        
    }
}
