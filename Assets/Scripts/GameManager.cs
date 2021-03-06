using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CarController> cars = new List<CarController>();
    public List<Voltas> laps = new List<Voltas>();
    public Transform[] spawnPoints;

    public float positionUpdateRate = 0.05f;
    private float lastPositionUpdateTime;

    public bool gameStarted = false;

    public int playersToBegin = 2;
    public int lapsToWin = 3;

    public static GameManager instance;

    public GameObject sunlight;
    private float lightPosition = 50.0f;
    
    void Awake ()
    {
        instance = this;
        //sunlight.transform.rotation = Quaternion.Euler(30, -30, 0);
    }

    void Update ()
    {
        // update the car race positions
        if(Time.time - lastPositionUpdateTime > positionUpdateRate)
        {
            lastPositionUpdateTime = Time.time;
            UpdateCarRacePositions();
        }

        // start the countdown when all cars are ready
        if(!gameStarted && cars.Count == playersToBegin)
        {
            gameStarted = true;
            StartCountdown();
        }
        if(lightPosition >= 50 && lightPosition <= 160){
            lightPosition += Time.deltaTime;
        } else if (lightPosition >= 360){
            lightPosition = 0;
        } else {
            lightPosition += 100*Time.deltaTime;
        }
        sunlight.transform.rotation = Quaternion.Euler(lightPosition, -30, 0);
    }

    // called when all players in in-game and ready to begin
    void StartCountdown ()
    {
        PlayerUI[] uis = FindObjectsOfType<PlayerUI>();

        for(int x = 0; x < uis.Length; ++x)
            uis[x].StartCountdownDisplay();

        Invoke("BeginGame", 3.0f);
    }

    // called after the countdown has ended and players can now race
    void BeginGame ()
    {
        for(int x = 0; x < cars.Count; ++x)
        {
            cars[x].canControl = true;
        }
    }

    // updates which car is coming first, second, etc
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

    // called when a car has crossed the finish line
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