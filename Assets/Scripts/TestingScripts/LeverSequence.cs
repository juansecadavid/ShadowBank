using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSequence : MonoBehaviour
{
    public int neededLevers;
    private int leverCounter;
    public GameObject doorGObjct;
    private Puertas door;

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
    {
        OpeningDoor();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ActivateLever();
            }
        }*/
    }

    public void ActivateLever()
    {
        leverCounter++;
        //gameObject.GetComponent<Collider2D>().SetActive(false);
    }

    public void OpeningDoor()
    {
        if(neededLevers == leverCounter)
        {
            door.Abrir();
        }
    }
}
