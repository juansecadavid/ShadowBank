using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float stoppingDistance = 3f;
    public float retreatDistance = 5f;
    public Vector3 startingPosition;


    private Transform playerPos;
    private MainCharacter playerObj;
    private Rigidbody2D rb2d;
    public bool canMove;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter>();
        rb2d = GetComponent<Rigidbody2D>();
        startingPosition= rb2d.position;
    }

    void FixedUpdate()
    {
        // Calcula la distancia entre el jugador y el fantasma
        float distanceToPlayer = Vector2.Distance(transform.position, playerPos.position);

        if (distanceToPlayer < retreatDistance)
        {
            // Si el jugador está dentro del rango de cercanía del fantasma
            if (distanceToPlayer < retreatDistance && canMove)
            {
                // Calcula la dirección hacia el jugador
                Vector2 direction = (playerPos.position - transform.position).normalized;

                // Comprueba si el jugador está mirando hacia el fantasma

                // Si el jugador está fuera del rango de parada, mueve el fantasma hacia el jugador
                if (distanceToPlayer > stoppingDistance)
                {
                    rb2d.velocity = direction * moveSpeed;
                }
                // Si el jugador está dentro del rango de parada, detiene el movimiento del fantasma
                else
                {
                    rb2d.velocity = Vector2.zero;
                }
            }
            // Si el jugador está fuera del rango de cercanía del fantasma, detiene el movimiento del fantasma
            else
            {
                rb2d.velocity = Vector2.zero;
            }
        }
        else
        {
            if(Vector2.Distance(transform.position,startingPosition)<0.2f)
            {
                rb2d.velocity = Vector2.zero;
            }
            else
            {
                Vector2 direction = (startingPosition - transform.position).normalized;
                rb2d.velocity = direction * moveSpeed;
            }
            
        }     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Catcher"))
        {
            rb2d.velocity = Vector2.zero;
            canMove = false;
        }
        if(collision.CompareTag("Player"))
        {
            playerObj.ChangeFear(3);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Catcher"))
        {
            canMove = true;
        }
    }
}
