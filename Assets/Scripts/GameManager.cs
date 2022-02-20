using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public List<CarController> cars = new List<CarController>();
    public Transform[] spawnPoints;

    public float positionUpdateRate = 0.05f;
    private float lastPositionUpdateTime;

    public bool gameStarted = false;

    public int playersToBegin = 2;
    public int lapsToWin = 3;

    public static GameManager instance;
    void Awake ()
    {
        instance = this;
    }

    void Update ()
    {
        // Atualizar as posições de corrida de carros
        if(Time.time - lastPositionUpdateTime > positionUpdateRate)
        {
            lastPositionUpdateTime = Time.time;
            UpdateCarRacePositions();
        }

        // Inicie a contagem regressiva quando todos os carros estiverem prontos
        if(!gameStarted && cars.Count == playersToBegin)
        {
            gameStarted = true;
            StartCountdown();
        }
    }

    // Chamado quando todos os jogadores estão no jogo e prontos para começar
    void StartCountdown ()
    {
        PlayerUI[] uis = FindObjectsOfType<PlayerUI>();

        for(int x = 0; x < uis.Length; ++x)
            uis[x].StartCountdownDisplay();

        Invoke("BeginGame", 3.0f);
    }
    
    // Chamado após a contagem regressiva terminar e os jogadores agora podem correr
    void BeginGame ()
    {
        for(int x = 0; x < cars.Count; ++x)
        {
            cars[x].canControl = true;
        }
    }


    // Atualiza qual carro vem primeiro, segundo, etc.
    void UpdateCarRacePositions ()
    {
        cars.Sort(SortPosition);

        for(int x = 0; x < cars.Count; x++)
        {
            cars[x].racePosition = cars.Count - x;
        }
    }

    int SortPosition (CarController a, CarController b)
    {
        if(a.zonesPassed > b.zonesPassed)
            return 1;
        else if(b.zonesPassed > a.zonesPassed)
            return -1;

        float aDist = Vector3.Distance(a.transform.position, a.curTrackZone.transform.position);
        float bDist = Vector3.Distance(b.transform.position, b.curTrackZone.transform.position);

        return aDist > bDist ? 1 : -1;
    }


    // Chamada quando um carro cruza a linha de chegada
    public void CheckIsWinner (CarController car)
    {
        if(car.curLap == lapsToWin + 1)
        {
            for(int x = 0; x < cars.Count; ++x)
            {
                cars[x].canControl = false;
            }

            PlayerUI[] uis = FindObjectsOfType<PlayerUI>();

            for(int x = 0; x < uis.Length; ++x)
                uis[x].GameOver(uis[x].car == car);
        }
    }
}
