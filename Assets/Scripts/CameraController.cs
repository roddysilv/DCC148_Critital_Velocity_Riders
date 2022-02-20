using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target; // alvo
    public float followSpeed; // velocidade
    public float rotateSpeed; // rotação

    // Chamada no primeiro frame
    void Start()
    {
       transform.parent = null;
    }

    // A cada frame, a camera se moverá junto ao alvo
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotateSpeed * Time.deltaTime);
    }
}
