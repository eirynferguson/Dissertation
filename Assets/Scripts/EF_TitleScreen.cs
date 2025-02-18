using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EF_TitleScreen : MonoBehaviour
{
    public GameObject controlUI;
    public static bool controlsShown = false;

    // Start is called before the first frame update
    void Start()
    {
        controlsShown = false; //hides UI for controls
        controlUI.SetActive(false); //sets UI as inactive
    }

    public void controls()
    {
        controlUI.SetActive(true); //show UI
        Time.timeScale = 0f;
        controlsShown = true;
    }

    public void back()
    {
        controlUI.SetActive(false);  //hide UI
        controlsShown = false;
    }
}
