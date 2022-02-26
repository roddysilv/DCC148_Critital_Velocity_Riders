using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voltas : MonoBehaviour
{
    //public List<CarController> cars = new List<CarController>();
    //public GameObject chegada;
    //public GameObject carro;
    public int voltas = 0;

    private bool entrou = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            if (entrou == false)
            {
                voltas++;
                //Debug.Log(voltas);
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

        //Debug.Log("AAAAHHHHH");
    }
}
