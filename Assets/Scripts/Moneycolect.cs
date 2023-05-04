using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Moneycolect : MonoBehaviour
{
    public TextMeshProUGUI moneyText; 
    private int contadorDinero = 0;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Dinero50") {
            contadorDinero+=50;
            moneyText.text = contadorDinero.ToString();

            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Dinero100") {
            contadorDinero+=100;
            moneyText.text = contadorDinero.ToString();

            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Dinero500") {
            contadorDinero+=500;
            moneyText.text = contadorDinero.ToString();

            Destroy(other.gameObject);
        }
    }
}
