using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject target; // El objeto que seguirá la cámara

    public float smoothSpeed = 0.125f; // La velocidad de movimiento suave de la cámara

    public Vector3 offset; // La posición de la cámara con respecto al objeto

    private void FixedUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
