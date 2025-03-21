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
    void Update()
    {

    }

    public void correctAns()
    {
        selectAnsTxt.SetActive(false);
        incorrectTxt.SetActive(false);
        correctTxt.SetActive(true);

        selectAnsTxt2.SetActive(false);
        incorrectTxt2.SetActive(false);
        correctTxt2.SetActive(true);

        points = 5;
        Debug.Log("Points = " + points);
    }

    public void incorrectAns()
    {
        selectAnsTxt.SetActive(false);
        correctTxt.SetActive(false);
        incorrectTxt.SetActive(true);

        selectAnsTxt2.SetActive(false);
        incorrectTxt2.SetActive(false);
        correctTxt2.SetActive(true);
    }
}
