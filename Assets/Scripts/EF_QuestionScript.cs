using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EF_QuestionScript : MonoBehaviour
{
    public GameObject correctTxt;
    public GameObject incorrectTxt;
    public GameObject selectAnsTxt;

    public int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        correctTxt.SetActive(false); 
        incorrectTxt.SetActive(false);
        selectAnsTxt.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void correctAns()
    {
        selectAnsTxt.SetActive(false);
        incorrectTxt.SetActive(false);
        correctTxt.SetActive(true);

        points = 5;
        Debug.Log("Points = " + points);
    }

    public void incorrectAns()
    {
        selectAnsTxt.SetActive(false);
        correctTxt.SetActive(false);
        incorrectTxt.SetActive(true);
    }
}
