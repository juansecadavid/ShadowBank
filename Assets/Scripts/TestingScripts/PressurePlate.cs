using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject doorGObjct;
    private Puertas door;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        door = doorGObjct.GetComponent<Puertas>();
    }

    // Update is called once per frame
    void Update()
    {/*
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {

            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            door.Abrir();
        }
    }
}
