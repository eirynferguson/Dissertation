using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EF_SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    //function used to switch between scenes
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        if (sceneName == "EndScreen")
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void exit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
