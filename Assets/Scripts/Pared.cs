using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    public GameObject pared;
    float contador=0f;
    Patrol padre;
    // Start is called before the first frame update
    void Start()
    {
        padre=GetComponentInParent<Patrol>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pared.activeInHierarchy)
        {
            contador += Time.deltaTime;
            if(contador > 20f)
            {
                pared.SetActive(false);
                contador = 0f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            pared.SetActive(true);
            padre.canMove = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            padre.canMove = true;
        }
    }
}
