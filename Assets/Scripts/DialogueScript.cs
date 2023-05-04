using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
  private bool isPlayerInRange;
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("se puede iniciar un dialogo");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("ya no se puede iniciar un dialogo");
        }
    }
    
}
