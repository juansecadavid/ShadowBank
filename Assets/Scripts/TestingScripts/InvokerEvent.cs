using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokerEvent : MonoBehaviour
{
    public UnityEvent invoker;
    private bool isInRange = false;

    //public int order = 0;

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
            if (Input.GetKeyDown(KeyCode.E))
            {
                invoker.Invoke();
                GetComponent<InvokerEvent>().enabled = false;
            }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
}
