using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PassCode : MonoBehaviour
{
    string code = "123";
    string number = null;
    int numberIndex = 0;
    string alpha;
    public TMP_Text uiText;
    int[] numbIndArray = new int[6];

    private void Start()
    {
        
    }

    public void CodeFunction(string numbers)
    {
        numberIndex++;
        number = number + numbers;
        uiText.text = number;
    }
    public void Enter()
    {
        if (number == code)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Delete()
    {
        numberIndex++;
        number = null;
        uiText.text = number;
    }
}