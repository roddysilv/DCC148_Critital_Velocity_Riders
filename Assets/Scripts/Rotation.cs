using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
   UnityEngine.AI.NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!agent.isStopped)
        {
            var targetPosition = agent.pathEndPosition;
            var targetPoint = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
            var _direction = (targetPoint - transform.position).normalized;
            var _lookRotation = Quaternion.LookRotation(_direction);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, 360);
        }
	}
}
