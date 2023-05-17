using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSequence : MonoBehaviour
{
    public int neededLevers;
    public int leverCounter;
    public GameObject doorGObjct;
    private Puertas door;

    private int isInOrder = 0;
    private bool canOpen = true;
    
    //private List<int> orderNeccesarly = new List<int>();

    [SerializeField]
    InvokerEvent[] leversForThis;

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
        FixedLevers();
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

    public void ActivateLever(int orderInSequence)
    {
        if (orderInSequence > isInOrder)
        {
            isInOrder = orderInSequence;
            leverCounter++;
        }
        else
        {
            canOpen = false;
            leverCounter++;
        }
    }
    public void FixedLevers()
    {
        if (neededLevers == leverCounter)
        {
            isInOrder = 0;
            canOpen = true;
            leverCounter = 0;

            for (int i = 0; i < leversForThis.Length; i++)
            {
                leversForThis[i].canUse=true;

                if(door.isOpen != true)
                {
                    leversForThis[i].ReverseChangeSprite();
                }
            }
        }
    }

    public void OpeningDoor()
    {
        if (neededLevers == leverCounter && canOpen == true)
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
