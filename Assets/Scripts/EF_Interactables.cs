using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EF_Interactables : MonoBehaviour
{
    public GameObject player;
    public string itemName;
    public GameObject infoSheet;
    public GameObject questionUI;

    EF_PlayerController playerScript;

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
    }

    public void RemoveObject()
    {
        this.gameObject.SetActive(false);
    }

    void OnInteract()
    {
        Debug.Log("Interacted");

        if (itemName == "Paper")
        {
            infoPaper(itemName);
        }
        else if (itemName == "Question Interact")
        {
            questionSheet(itemName);
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
        Time.timeScale = 0f;
    }

    public void back()
    {
        infoSheet.SetActive(false);
        questionUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
