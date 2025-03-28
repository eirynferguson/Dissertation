using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EF_QuestionScript : MonoBehaviour
{
    public GameObject correctTxt;
    public GameObject incorrectTxt;
    public GameObject selectAnsTxt;

    public GameObject correctTxt2;
    public GameObject incorrectTxt2;
    public GameObject selectAnsTxt2;

    public int points = 0;

    bool correct = false;
    bool incorrect = false;
    bool correct2 = false;
    bool incorrect2 = false;

    // Start is called before the first frame update
    void Start()
    {
        correctTxt.SetActive(false);
        incorrectTxt.SetActive(false);
        selectAnsTxt.SetActive(true);

        correctTxt2.SetActive(false);
        incorrectTxt2.SetActive(false);
        selectAnsTxt2.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (incorrect == true)
        {
            incorrectTxt.SetActive(false);
            selectAnsTxt.SetActive(true);
        }
        else if (incorrect2 == true)
        {
            incorrectTxt2.SetActive(false);
            selectAnsTxt2.SetActive(true);
        }
        else if (correct == true)
        {
            correctTxt.SetActive(true);
            selectAnsTxt.SetActive(false);
        }
        else if (correct2 == true) 
        {
            correctTxt2.SetActive(true);
            selectAnsTxt2.SetActive(false);
        }
    }

    public void correctAns()
    {
        correct = true;

        selectAnsTxt.SetActive(false);
        incorrectTxt.SetActive(false);
        correctTxt.SetActive(true);

        points = points + 5;
        Debug.Log("Points = " + points);
    }

    public void correctAns2()
    {
        correct2 = true;

        selectAnsTxt2.SetActive(false);
        incorrectTxt2.SetActive(false);
        correctTxt2.SetActive(true);

        points = points + 5;
        Debug.Log("Points = " + points);
    }

    public void incorrectAns()
    {
        incorrect = true;

        selectAnsTxt.SetActive(false);
        correctTxt.SetActive(false);
        incorrectTxt.SetActive(true);
    }

    public void incorrectAns2()
    {
        incorrect2 = true;

        selectAnsTxt2.SetActive(false);
        correctTxt2.SetActive(false);
        incorrectTxt2.SetActive(true);
    }
}
