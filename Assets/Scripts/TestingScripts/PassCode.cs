using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PassCode : MonoBehaviour
{
    private string code = "";
    private bool activePanelCode = false;
    private string number = null;
    private int numberIndex = 0;
    private string alpha;
    public TMP_Text uiText;
    private int[] numbIndArray = new int[6];
    private InteractionZone interactZone;

    private void Start()
    {
        //gameObject.SetActive(false);
    }

    private void Awake()
    {
        gameObject.SetActive(false);
        code = interactZone.codeBlock;
    }

    public void CodePanel()
    {
        if(activePanelCode == false)
        {
            gameObject.SetActive(true);
            activePanelCode = true;
        }
        else
        {
            gameObject.SetActive(false);
            activePanelCode = false;
        }
    }

    public void CodeFunction(string numbers)
    {
        numberIndex++;
        number = number + numbers;
        uiText.text = number;
    }
    public void Enter()
    {
        if (IsCodeEquals() == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    public void Delete()
    {
        numberIndex++;
        number = null;
        uiText.text = number;
    }

    public bool IsCodeEquals()
    {
        if (number == code)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}