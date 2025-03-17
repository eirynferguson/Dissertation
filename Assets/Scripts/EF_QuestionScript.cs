using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EF_QuestionScript : MonoBehaviour
{
    public GameObject correctTxt;
    public GameObject incorrectTxt;
    public GameObject inputText;
    public string ansText;

    // Start is called before the first frame update
    void Start()
    {
        //ansText = inputText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void submitAns()
    {
        if (inputText != null)
        {
            if (inputText = "A")
            {
                correctTxt.SetActive(true);
            }
            else
            {
                incorrectTxt.SetActive(true);
            }
        }

    }*/
}
