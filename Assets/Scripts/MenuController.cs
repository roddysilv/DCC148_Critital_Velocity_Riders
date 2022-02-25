using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject quitButton; // quitButton object
    public GameObject startButton; // startButton object
    public GameObject introPanel; // introPanel object
    public GameObject mainMenu; // mainMenu object
    public TMPro.TextMeshProUGUI gameTitle;
    private float menuTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //force disable the end game menu buttons
        //restartButton.gameObject.SetActive(false);
        //quitButton.gameObject.SetActive(false);
        mainMenu.SetActive(false);
        gameTitle.text = ""; // clear the text
        introPanel.SetActive(true); // enable the intro panel
    }

    // Update is called once per frame
    void Update()
    {
        menuTime += Time.deltaTime;
        gameTitleTypeAnimation();
        if (menuTime >= 5.0f)
        {
            introPanel.SetActive(false);
            mainMenu.SetActive(true);
            //startButton.SetActive(true);
            //quitButton.SetActive(true);
        }
    }

    public void startGame()
    {
        //start the game
        //SceneManager.LoadScene("Game");
        SceneManager.LoadScene("SampleScene");
    }
    public void quitGame()
    {
        Debug.Log("You have clicked the quit button!");
        Application.Quit();
    }

    private void gameTitleTypeAnimation()
    {
        //menuTime += Time.deltaTime;
        if (menuTime >= 0.5f && menuTime < 1.0f)
        {
            gameTitle.text = "G";
        }
        if (menuTime >= 1.0f && menuTime < 1.5f)
        {
            gameTitle.text = "Ga";
        }
        if (menuTime >= 1.5f && menuTime < 2.5f)
        {
            gameTitle.text = "Gam";
        }
        if (menuTime >= 2.5f && menuTime < 3.0f)
        {
            gameTitle.text = "Game";
        }
    }
}
