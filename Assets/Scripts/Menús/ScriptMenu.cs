using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    public static bool gameP=false;
    public static bool boolseguroP;

    public GameObject menuP, seguroP;

    AudioSource mordida;
    private void Start()
    {
        menuP.SetActive(false);
        seguroP.SetActive(false);
        mordida = GetComponent<AudioSource>();

    }

    public void SwitchPause()
    {
        if (gameP)
        {
            bntResume();         
        }
        else
        {
            btnPause();
            
        }
    }


    void bntResume()
    {
        menuP.SetActive(false);
        Time.timeScale = 1;
        gameP = false;
        mordida.Play();
    }

    void btnPause()
    {
        menuP.SetActive(true);
        Time.timeScale = 0;
        gameP = true;
        mordida.Play();
    }

    public void mPrincipal()
    {
        SceneManager.LoadScene("Inicio");
        Time.timeScale = 1;
        mordida.Play();
    }

    public void Panel2()
    {
        seguroP.SetActive(true);
        mordida.Play();
    }

    public void salirPno()
    {
        seguroP.SetActive(false);
        mordida.Play();
    }

    public void salirPsi()
    {
        Debug.Log("Se ha salido del juego");
        Application.Quit();
        mordida.Play();
    }
}

