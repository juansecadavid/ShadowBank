using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    public GameObject player;
    public GameObject uCode;

    private void Start()
    {
        uCode.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            uCode.SetActive(true);
        }
    }
}
