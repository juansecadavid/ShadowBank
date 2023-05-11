using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokerEvent : MonoBehaviour
{
    public UnityEvent invoker;
    private bool isInRange = false;

    [SerializeField]
    private SpriteRenderer objectToRender;

    [SerializeField]
    private Sprite startSprite;

    [SerializeField]
    private Sprite newSprite;

    //public int order = 0;

    private void Start()
    {
        objectToRender = gameObject.GetComponent<SpriteRenderer>();
        ChangeSprite(startSprite);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
            if (Input.GetKeyDown(KeyCode.E))
            {
                invoker.Invoke();
                GetComponent<InvokerEvent>().enabled = false;
                ChangeSprite(newSprite);
            }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    public void ChangeSprite(Sprite sprite)
    {
        objectToRender.sprite = sprite;
    }
}
