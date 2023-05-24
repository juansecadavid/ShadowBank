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
    //instancia de objeto
    public GameObject interactZ;
    private InteractionZone interactZone;
    public GameObject doorGObjct;
    private Puertas door;

    private void Start()
    {
        //gameObject.SetActive(false);
    }

    private void Awake()
    {
        interactZone = interactZ.GetComponent<InteractionZone>();
        gameObject.SetActive(false);
        code = interactZone.codeBlock;
        door = doorGObjct.GetComponent<Puertas>();
    }

    private void Update()
    {
        CodeFunction();
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

    public void CodeFunction(/*string numbers*/)
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            number = number + "0";
            uiText.text = number;
            numberIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            number = number + "1";
            uiText.text = number;
            numberIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            number = number + "2";
            uiText.text = number;
            numberIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            number = number + "3";
            uiText.text = number;
            numberIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
                number = number + "4";
            uiText.text = number;
            numberIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            number = number + "5";
            uiText.text = number;
            numberIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            number = number + "6";
            uiText.text = number;
            numberIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            number = number + "7";
            uiText.text = number;
            numberIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            number = number + "8";
            uiText.text = number;
            numberIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            number = number + "9";
            uiText.text = number;
            numberIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            number = "";
            uiText.text = number;
            numberIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            EnterCode();
        }
        
    }

    public void EnterCode()
    {
        if(uiText.text == "1430")
        {
            door.Abrir();
            gameObject.SetActive(false);
        }
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