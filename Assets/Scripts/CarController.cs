using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public float acceleration;
    public float turnSpeed;

    public Transform carModel;
    private Vector3 startModelOffset;

    public float groundCheckRate;
    private float lastGroundCheckTime;

    private float curYRot;

    public bool canControl;

    private bool accelerateInput;
    private float turnInput;

    public TrackZone curTrackZone;
    public int zonesPassed;
    public int racePosition;
    public int curLap;

    public Rigidbody rig;

    public AudioSource engineSound;

    void Start ()
    {
        startModelOffset = carModel.transform.localPosition;
        GameManager.instance.cars.Add(this);
        transform.position = GameManager.instance.spawnPoints[GameManager.instance.cars.Count - 1].position;
        engineSound.volume = 0;
    }

    void Update ()
    {
        // disable the ability to turn if we cannot control the car
        if(!canControl)
            turnInput = 0.0f;

        // calculate the amount we can turn based on the dot product between our velocity and facing direction
        float turnRate = Vector3.Dot(rig.velocity.normalized, carModel.forward);
        turnRate = Mathf.Abs(turnRate);

        curYRot += turnInput * turnSpeed  * turnRate * Time.deltaTime;

        carModel.position = transform.position + startModelOffset;
        //carModel.eulerAngles = new Vector3(0, curYRot, 0);

        CheckGround();
    }

    void FixedUpdate ()
    {
        // don't accelerate if we don't have control
        if(!canControl)
            return;

        if(accelerateInput == true)
        {
            rig.AddForce(carModel.forward * acceleration, ForceMode.Acceleration);
        }
    }

    // rotate with the surface below us
    void CheckGround ()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, -0.75f, 0), Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1.0f))
        {
            carModel.up = hit.normal;
        }
        else
        {
            carModel.up = Vector3.up;
        }

        carModel.Rotate(new Vector3(0, curYRot, 0), Space.Self);
    }

    // called when we press down the accelerate input
    public void OnAccelerateInput (InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed){
            accelerateInput = true;
            if(canControl)
            engineSound.volume = 0.4f;
        }
        else {
            accelerateInput = false;
            engineSound.volume = 0;
        }
    }

    // called when we modify the turn input
    public void OnTurnInput (InputAction.CallbackContext context)
    {
        turnInput = context.ReadValue<float>();
    }
}