using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSequence : MonoBehaviour
{
    public int neededLevers;
    private int leverCounter;
    public GameObject doorGObjct;
    private Puertas door;
    /*
    private List<int> orderNeccesarly = new List<int>();

    [SerializeField]
    InvokerEvent[] leversForThis;
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        door = doorGObjct.GetComponent<Puertas>();
        /*FillList(orderNeccesarly);

        for (int i = 0; i < neededLevers; i++)
        {
            leversForThis[i].order = i;
        }*/
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
    }

    public void OpeningDoor()
    {
        if(neededLevers == leverCounter)
        {
            door.Abrir();
        }
    }
    /*
    public void FillList(List<int> list)
    {
        for (int i = 0; i < neededLevers; i++)
        {
            list[i] = i;
        }
    }*/
}
