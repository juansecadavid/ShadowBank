using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PassCode : MonoBehaviour
{
    string Code = "123";
    string Number = null;
    int NumberIndex = 0;
    string alpha;
    public TMP_Text UiText;

    public void CodeFunction(string Numbers)
    {
        NumberIndex++;
        Number = Number + Numbers;
        UiText.text = Number;

    }
    public void Enter()
    {
        if (Number == Code)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Delete()
    {
        NumberIndex++;
        Number = null;
        UiText.text = Number;
    }
}