using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPressurePlate : MonoBehaviour
{
    public bool isOpen;
    public int manyPressures;
    public int neccesarlyComponents;
    public GameObject pressures;
    private PressurePlate plate;

    SpriteRenderer renderer;

    public int isInOrder = 0;
    public bool canOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        plate = pressures.GetComponent<PressurePlate>();
    }

    // Update is called once per frame
    void Update()
    {
        Abrir();
        EndPressures();
    }

    public void Abrir()
    {
        if (manyPressures == neccesarlyComponents && canOpen == true)
        {
            isOpen = true;
            renderer.sprite=null;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
            
    }

    public void ActivatePressurePlate(int orderInSequence)
    {
        if (orderInSequence > isInOrder)
        {
            isInOrder = orderInSequence;
            manyPressures++;
        }
        else
        {
            canOpen = false;
            manyPressures++;
        }
    }

    public void EndPressures()
    {
        if(manyPressures == neccesarlyComponents)
        {
            isInOrder = 0;
            canOpen = true;
            manyPressures = 0;
        }
    }
    /*
    public void IncreaseCount()
    {
        manyPressures++;
    }*/

    public void DecreaseCount()
    {
        manyPressures--;
        isInOrder = 0;
    }
}
