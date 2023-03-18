using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    public void salirPsi()
    {
        Debug.Log("Se ha salido del juego");
        Application.Quit();
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Levels Menu");
    }
}
