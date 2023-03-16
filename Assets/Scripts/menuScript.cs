using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    public GameObject menuButton,startButton;
    public GameObject instructionButton,quitButton;

    public GameObject instructionText;

    // Start is called before the first frame update
    void Start()
    {
        instructionText.SetActive(false);
        instructionButton.SetActive(true);
        menuButton.SetActive(false);
        startButton.SetActive(true);
        quitButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showInstructions()
    {
        startButton.SetActive(false);
        instructionText.SetActive(true);
        instructionButton.SetActive(false);
        menuButton.SetActive(true);
        quitButton.SetActive(false);
    }

    public void hideInstructions()
    {
        startButton.SetActive(true);
        instructionText.SetActive(false);
        instructionButton.SetActive(true);
        menuButton.SetActive(false);
        quitButton.SetActive(true);
    }

}
