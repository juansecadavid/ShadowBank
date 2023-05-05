using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStatue : MonoBehaviour
{
    Statues statues;
    // Start is called before the first frame update
    private void Start()
    {
        
        statues = gameObject.GetComponentInParent<Statues>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            statues.canMove = true;
        }
    }
}
