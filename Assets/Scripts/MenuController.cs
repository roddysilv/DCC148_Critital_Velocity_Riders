using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject quitButton; // quitButton object
    public GameObject startButton; // restartButton object
    // Start is called before the first frame update
    void Start()
    {
        //force disable the end game menu buttons
        //restartButton.gameObject.SetActive(false);
        //quitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
