using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraEnergía : MonoBehaviour
{
    MainCharacter character;
    public float barraEnergia;
    public float coolDown;
    public Slider slider;
    public float maxTime;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<MainCharacter>();
        slider.maxValue = maxTime;
        slider.value = maxTime;
        coolDown = 5f;
        barraEnergia = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)&&barraEnergia>0f)
        {
            if(barraEnergia>0f)
            {
                barraEnergia -= Time.deltaTime; 
                slider.value = barraEnergia;
            }          
        }
        
        else
        {
            if(barraEnergia < 0f)
            {
                character.canRun = false;
                coolDown-= Time.deltaTime;
            }
            if (coolDown < 0f)
            {
                ChangeMaxTime();
                if (barraEnergia < maxTime)
                {
                    barraEnergia += Time.deltaTime;
                    character.canRun = true;
                    slider.value = barraEnergia;
                    coolDown = 5f;
                }
            }
            else if (barraEnergia>0f&&barraEnergia<maxTime)
            {
                barraEnergia += Time.deltaTime;
                slider.value = barraEnergia;
            }           
        }
    }

    void ChangeMaxTime()
    {
        float rand = Random.Range(3f,6f);
        maxTime = rand;
    }
}
