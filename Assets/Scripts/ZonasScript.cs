using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonasScript : MonoBehaviour
{
    public int zones;
    void Start()
    {
        zones = 0;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            zones++;
            GameManagerController gameManager=FindObjectOfType<GameManagerController>();
            gameManager.GetZones(zones);
            Destroy(gameObject);
        }
    }
}
