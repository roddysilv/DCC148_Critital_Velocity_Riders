using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Voltas : MonoBehaviour
{
    public List<CarController> cars = new List<CarController>();

    //public GameObject chegada;
    //public GameObject carro;
    public int voltasCompletas = 0;

    private int voltas = 3;

    public bool isPlayer;

    public TextMeshProUGUI gameOverText;

    private bool entrou = false;

    private float menuTimer = 5.0f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            if (entrou == false)
            {
                voltasCompletas++;
                entrou = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (entrou == true)
        {
            entrou = false;
        }
    }

    void Update()
    {
        if (voltasCompletas >= voltas + 1)
        {
            //Debug.Log("Corrida Terminada!");
            cars[0].canControl = false;
            if (isPlayer)
            {
                GameOver(true);
            }
        }

        if (
            voltasCompletas > 0 &&
            voltasCompletas < voltas + 1 &&
            cars[0].canControl == false
        )
        {
            if (isPlayer)
            {
                GameOver(false);
            }
        }
    }

    public void GameOver(bool winner)
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.color = winner == true ? Color.green : Color.red;
        gameOverText.text = winner == true ? "Você Ganhou!" : "Você Perdeu!";
        menuTimer -= Time.deltaTime;
        if (menuTimer <= 0.0f)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
