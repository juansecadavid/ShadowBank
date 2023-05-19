using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesColects : MonoBehaviour
{
    public int notes;
    void Start()
    {
        notes = 0;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            notes++;
            GameManagerController gameManager=FindObjectOfType<GameManagerController>();
            gameManager.GetNotes(notes);
            Destroy(gameObject);
        }
    }
}
