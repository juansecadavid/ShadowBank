using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptM3 : MonoBehaviour
{
    public static bool gameP;
    public static bool boolseguroP;

    public GameObject menuP, seguroP;

    private void Start()
    {
        menuP.SetActive(false);
        seguroP.SetActive(false);

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
    }

    void btnPause()
    {
        menuP.SetActive(true);
        Time.timeScale = 0;
        gameP = true;
    }

    public void mPrincipal(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }

    public void Panel2()
    {
        seguroP.SetActive(true);
    }

    public void salirPno()
    {
        seguroP.SetActive(false);
    }

    public void salirPsi()
    {
        Debug.Log("Se ha salido del juego");
        Application.Quit();
    }
}
