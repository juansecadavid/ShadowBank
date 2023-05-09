using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableStatue : MonoBehaviour
{
    public GameObject statue;
    public float pushDistance = 0f;
    public float speed = 2f;

    bool collideTop = false;
    bool collideBottom = false;
    bool collideRight = false;
    bool collideLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collideTop)
        {
            transform.Translate(0, 0, pushDistance);
        }
        else if (collideBottom)
        {
            transform.Translate(0, 0, -pushDistance);
        }
        else if (collideRight)
        {
            transform.Translate(pushDistance, 0, 0);
        }
        else if (collideLeft)
        {
            transform.Translate(-pushDistance, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D  collision) 
    {
        Collider2D collider = collision.collider;
        float colliderReWidth = GetComponent<Collider2D>().bounds.size.x;
        float colliderReHeight = GetComponent<Collider2D>().bounds.size.y;
        float objectCollider = collider.bounds.size.x;

        //Luego es mirar con GetContact si no ha conseguido la información correctamente
        if (collision.gameObject.CompareTag("Player"))
        { 
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collider.bounds.center;

            if (contactPoint.y > center.y && contactPoint.x < center.x + colliderReWidth / 2 && contactPoint.x > center.x - colliderReWidth / 2)
            {
                collideTop = true;
            }
            else if (contactPoint.y < center.y && contactPoint.x < center.x + colliderReWidth / 2 && contactPoint.x > center.x - colliderReWidth / 2)
            {
                collideBottom = true;
            }
            else if (contactPoint.x > center.x && contactPoint.y < center.y + colliderReHeight / 2 && contactPoint.y > center.y - colliderReHeight / 2)
            {
                collideRight = true;
            }
            else if (contactPoint.x < center.x && contactPoint.y < center.y + colliderReHeight / 2 && contactPoint.y > center.y - colliderReHeight / 2)
            {
                collideLeft = true;
            }
        }
    }
}
