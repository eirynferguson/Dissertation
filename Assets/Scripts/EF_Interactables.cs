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
    public GameObject twoQuestionUI;
    public GameObject threeQuestionUI;
    public GameObject pointsUI;
    public GameObject keyUI;

    public GameObject key;
    public GameObject nextLevel;

    public string itemName;
    public bool hasKey = false;

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

    public void RemoveObject()
    {
        this.gameObject.SetActive(false);
    }

    void OnInteract()
    {
        Debug.Log("Interacted");

        if (pauseScript.isPaused == false) //prevents other UI showing ontop of pause menu 
        {
            if (itemName == "Paper")
            {
                infoPaper();
            }
            else if (itemName == "Question 1")
            {
                questionSheet();
            }
            else if (itemName == "Question 2")
            {
                questionSheet2();
            }
            else if (itemName == "Question 3")
            {
                questionSheet3();
            }
            else if (itemName == "Next Level")
            {
                loadNextLevel();
            }
            else if (itemName == "Key")
            {
                holdKey(hasKey);

                Debug.Log("Returns: " + hasKey);
            }
            else if (itemName == "Door")
            {
                Debug.Log("Has Key = " + hasKey);
                openDoor(hasKey);
            }
        }
    }

    void infoPaper()
    {
        Debug.Log("Info Sheet");

        Cursor.lockState = CursorLockMode.None;
        infoSheet.SetActive(true);
        Time.timeScale = 0f;
    }

    void questionSheet()
    {
        Debug.Log("Question");

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;

        questionUI.SetActive(true);
        twoQuestionUI.SetActive(false);
        threeQuestionUI.SetActive(false);
    }

    void questionSheet2()
    {
        Debug.Log("Question 2");

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;

        questionUI.SetActive(false);
        twoQuestionUI.SetActive(true);
        threeQuestionUI.SetActive(false);  
    }

    void questionSheet3()
    {
        Debug.Log("Question 3");

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;

        questionUI.SetActive(false);
        twoQuestionUI.SetActive(false);
        threeQuestionUI.SetActive(true);
    }

    void loadNextLevel()
    {
        if (questionScript.points == 15)
        {
            Debug.Log("Next Level");
            key.SetActive(true);
        }
        else
        {
            pointsUI.SetActive(true);
            StartCoroutine(wait(pointsUI));
        }
    }

    IEnumerator wait(GameObject item)
    {
        Debug.Log("Start wait");

        yield return new WaitForSeconds(3);

        item.SetActive(false);

        Debug.Log("End wait");
    }

    void holdKey(bool pocketKey)
    {
        Debug.Log("key");

        RemoveObject();
        pocketKey = true; 

        Debug.Log(pocketKey); //returns true

        /*if (pocketKey == true)
        {
            OnInteract();
        }*/
    }

    void openDoor(bool useKey)
    {
        Debug.Log("HasKey = " + useKey);

        if (useKey == false)
        {
            Debug.Log("Door Locked");
            keyUI.SetActive(true);
            StartCoroutine(wait(keyUI));
        }
        else if (useKey == true)
        {
            Debug.Log("Unlocked");
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
        twoQuestionUI.SetActive(false);
        threeQuestionUI.SetActive(false);
    }
}
