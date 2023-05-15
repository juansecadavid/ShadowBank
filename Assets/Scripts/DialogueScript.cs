using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;

    private float typingTime = 0.05f;

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private GameManagerController gameManagerController;
    public bool isImportant;
    bool firstCall;
    private void Start()
    {
        gameManagerController=FindObjectOfType<GameManagerController>();
        firstCall=true;
    }
    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.Return))
        {
            if(firstCall==true&&isImportant)
            {
                gameManagerController.NPCMission();
                firstCall = false;
            }
            if(!didDialogueStart)
            {
                StartDialogue();
            }
        }
        /*else if(dialogueText.text == dialogueLines[1])
        {
            
            NextDialogueLine();
        }*/
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    /*private void NextDialogueLine()
    {
       lineIndex++;
       if(lineIndex < dialogueLines.Length)
       {
         StartCoroutine(ShowLine());
       }
       else
       {
         didDialogueStart = false;
         dialoguePanel.SetActive(false);
         dialogueMark.SetActive(true);
       }
    }*/


    private void StopDialogue()
    {
        didDialogueStart = false;
        dialoguePanel.SetActive(false);
        dialogueMark.SetActive(false);
        lineIndex = 0;
    }

   

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            didDialogueStart = false;
            dialoguePanel.SetActive(false); 
        }
    }
    
}
