using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EF_Cursor : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    public Image playerView;
    bool isInteract;

    EF_PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent <EF_PlayerController>();
        mainCamera = playerScript.mainCamera;
        playerView = playerView.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.targetObject != null)
        {
            isInteract = true;
            interactable();
        }
        else
        {
            isInteract = false;
            interactable();
        }
    }

    void interactable()
    {
        if (isInteract)
        {
            playerView.color = new Color32(255, 0, 0, 255);
        }
        else
        {
            playerView.color = new Color32(255, 255, 255, 255);
        }
    }
}
