using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llaves : MonoBehaviour
{
    // Start is called before the first frame update
    public Puertas puertaAbrir; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision!=null)
        {
            if(collision.CompareTag("Player"))
            {
                puertaAbrir.Abrir();
                Destroy(gameObject);
            }
        }
    }
}
