using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject target; // El objeto que seguir� la c�mara

    public float smoothSpeed = 0.125f; // La velocidad de movimiento suave de la c�mara

    public Vector3 offset; // La posici�n de la c�mara con respecto al objeto

    private void FixedUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
