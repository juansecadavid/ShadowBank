using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    SpriteRenderer renderer;
    public GameObject _object;

    public bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            isOpen = true;
            renderer.sprite = null;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _object.SetActive(false);
        }
    }
    public void Abrir()
    {
        isOpen = true;
    }
}
