using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokerEvent : MonoBehaviour
{
    public UnityEvent invoker;
    public bool isInRange = false;
    public bool canUse;
    public int asignedNumber;
    [SerializeField]
    private SpriteRenderer objectToRender;

    [SerializeField]
    private Sprite startSprite;

    [SerializeField]
    private Sprite newSprite;

    LeverSequence lever;

    //public int order = 0;

    private void Start()
    {
        lever=FindFirstObjectByType<LeverSequence>();
        objectToRender = gameObject.GetComponent<SpriteRenderer>();
        ChangeSprite(startSprite);
        canUse = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUse)
        {
            if (isInRange)
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //invoker.Invoke();
                    lever.ActivateLever(asignedNumber);
                    canUse = false;
                    //GetComponent<InvokerEvent>().enabled = false;
                    ChangeSprite(newSprite);
                }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    public void ChangeSprite(Sprite sprite)
    {
        objectToRender.sprite = sprite;
    }
}
