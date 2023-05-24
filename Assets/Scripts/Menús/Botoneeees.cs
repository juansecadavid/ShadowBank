using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botoneeees : MonoBehaviour
{
    public void Volver()
    {
        SceneManager.LoadScene("Noche");
    }

    public void SalirMenu()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void ContinuarNoche()
    {
        SceneManager.LoadScene("Noche");
    }
}
