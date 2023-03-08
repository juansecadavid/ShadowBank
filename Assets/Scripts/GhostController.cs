using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float stoppingDistance = 3f;
    public float retreatDistance = 5f;

    private Transform player;
    private Rigidbody2D rb2d;
    public bool canMove;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Calcula la distancia entre el jugador y el fantasma
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de cercanía del fantasma
        if (distanceToPlayer < retreatDistance&&canMove)
        {
            // Calcula la dirección hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Catcher"))
        {
            canMove = false;
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
