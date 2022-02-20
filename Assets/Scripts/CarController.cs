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

    void Start ()
    {
        startModelOffset = carModel.transform.localPosition; // ajusta a posição do carro
        GameManager.instance.cars.Add(this);
        transform.position = GameManager.instance.spawnPoints[GameManager.instance.cars.Count - 1].position;
    }

    void Update(){

        // Desativar a capacidade de virar se não pudermos controlar o carro
        if(!canControl)
            turnInput = 0.0f;

    	float turnRate = Vector3.Dot(rig.velocity.normalized, carModel.forward);
        turnRate = Mathf.Abs(turnRate);

        // giro do carro
    	curYRot += turnInput * turnSpeed  * turnRate * Time.deltaTime;
        carModel.position = transform.position + startModelOffset;

        CheckGround();
    }

     void FixedUpdate()
    {	
        // Não acelere se não tivermos controle
        if(!canControl)
            return;
            
        if(accelerateInput == true)
        {	// aceleração do carro
            rig.AddForce(carModel.forward * acceleration, ForceMode.Acceleration);
        }
    }

    // Girar com a superfície
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

    // Chamada quando pressionamos a tecla de aceleração
	public void OnAccelerateInput (InputAction.CallbackContext context)
	{
    	if(context.phase == InputActionPhase.Performed)
        	accelerateInput = true;
    	else
        	accelerateInput = false;
	}

	// Chamada quando pressionamos a tecla de giro
	public void OnTurnInput (InputAction.CallbackContext context)
	{
    	turnInput = context.ReadValue<float>();
	}
}