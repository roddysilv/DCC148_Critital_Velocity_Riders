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
    public TMPro.TextMeshProUGUI gameTitle2;
    private float menuTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //force disable the main menu and clears the text
        mainMenu.SetActive(false);
        gameTitle.text = ""; // clear the text
        gameTitle2.text = ""; // clear the text
        introPanel.SetActive(true); // enable the intro panel
    }

    // Update is called once per frame
    void Update()
    {
        menuTime += Time.deltaTime;
        gameTitleTypeAnimation();
        if (menuTime >= 4.5f)
        {
            introPanel.SetActive(false);
            mainMenu.SetActive(true);
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
        if (menuTime >= 0.125f && menuTime < 0.25f)
        {
            gameTitle.text = "C";
        }
        if (menuTime >= 0.25f && menuTime < 0.375f)
        {
            gameTitle.text = "CR";
        }
        if (menuTime >= 0.375f && menuTime < 0.5f)
        {
            gameTitle.text = "CRI";
        }
        if (menuTime >= 0.5f && menuTime < 0.625f)
        {
            gameTitle.text = "CRIT";
        }
        if (menuTime >= 0.625f && menuTime < 0.750f)
        {
            gameTitle.text = "CRITI";
        }
        if (menuTime >= 0.750f && menuTime < 0.875f)
        {
            gameTitle.text = "CRITIC";
        }
        if (menuTime >= 0.875f && menuTime < 1.0f)
        {
            gameTitle.text = "CRITICA";
        }
        if (menuTime >= 1.0f && menuTime < 1.125f)
        {
            gameTitle.text = "CRITICAL";
        }
        if (menuTime >= 1.125f && menuTime < 1.25f)
        {
            gameTitle.text = "CRITICAL ";
        }
        if (menuTime >= 1.25f && menuTime < 1.375f)
        {
            gameTitle.text = "CRITICAL V";
        }
        if (menuTime >= 1.375f && menuTime < 1.5f)
        {
            gameTitle.text = "CRITICAL VE";
        }
        if (menuTime >= 1.5f && menuTime < 1.625f)
        {
            gameTitle.text = "CRITICAL VEL";
        }
        if (menuTime >= 1.625f && menuTime < 1.750f)
        {
            gameTitle.text = "CRITICAL VELO";
        }
        if (menuTime >= 1.750f && menuTime < 1.875f)
        {
            gameTitle.text = "CRITICAL VELOC";
        }
        if (menuTime >= 1.875f && menuTime < 2.0f)
        {
            gameTitle.text = "CRITICAL VELOCI";
        }
        if (menuTime >= 2.0f && menuTime < 2.125f)
        {
            gameTitle.text = "CRITICAL VELOCIT";
        }
        if (menuTime >= 2.125f && menuTime < 2.5f)
        {
            gameTitle.text = "CRITICAL VELOCITY";
        }
        if (menuTime >= 2.5f && menuTime < 3.0f)
        {
            //gameTitle.text = "CRITIAL VELOCITY";
            gameTitle2.text = "RIDERS";
        }
    }
}
