using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuP2 : MonoBehaviour
{
    public GameObject Panel;
    public GameObject PanelP;
    void Start()
    {
        Panel.SetActive(false);
    }

    public void BotonJugar()
    {
        Panel.SetActive(true);
        PanelP.SetActive(false);
    }

    public void InicioPartida1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void InicioPartida2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void InicioPartida3()
    {
        SceneManager.LoadScene("Level 3");
    }
}
