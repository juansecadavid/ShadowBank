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


    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    private void Awake()
    {
        plate = pressures.GetComponent<PressurePlate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manyPressures == neccesarlyComponents)
        {
            Abrir();
        }
    }

    public void Abrir()
    {
        isOpen = true;
    }

    public void IncreaseCount()
    {
        manyPressures++;
    }

    public void DecreaseCount()
    {
        manyPressures--;
    }
}
