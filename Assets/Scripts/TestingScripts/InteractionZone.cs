using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionZone : MonoBehaviour
{
    //public GameObject player;
    public GameObject uCode;
    private PassCode passCode;
    public string codeBlock = "";

    public bool isInRange;
    public KeyCode interact;
    public UnityEvent interactAction;

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interact))
            {
                interactAction.Invoke();
            }
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("En contacto");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("En contacto");
        }
    }
    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MainCharacter1"))
        {
            isInRange = true;
            Debug.Log("Fuera de Contacto");
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainCharacter1"))
        {
            isInRange = false;
            Debug.Log("Fuera de Contacto");
        }
    }
}