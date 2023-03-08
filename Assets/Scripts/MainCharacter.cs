using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    public float speed = 5f; // Velocidad de movimiento del personaje
    public float moveDelay; // Tiempo de retraso entre movimientos
    public bool canMove = true; // Indica si el jugador puede moverse

    private Rigidbody2D rb2d; // Componente Rigidbody2D del personaje
    private Vector2 input; // Almacenará las entradas del jugador
    private float moveTimer = 0f; // Timer para el retraso entre movimientos

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            // Obtener entradas de teclado
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // Restringir el movimiento en un solo eje
            /*if (Mathf.Abs(input.x) > 0f)
            {
                input.y = 0f;
            }
            else if (Mathf.Abs(input.y) > 0f)
            {
                input.x = 0f;
            }*/

            // Si se presiona una dirección, mover al personaje
            if (input != Vector2.zero && moveTimer <= 0f)
            {
                Move();
                float angle = Mathf.Atan2(-input.x, input.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                moveTimer = moveDelay;
            }
        }
        else
        {
            input = Vector2.zero;
        }

        // Actualizar el temporizador de movimiento
        if (moveTimer > 0f)
        {
            moveTimer -= Time.deltaTime;
        }

        //Codigo para fantasma

        // Obtener una referencia al objeto del fantasma
        GameObject ghost = GameObject.FindGameObjectWithTag("Ghost");

        // Comprobar si el jugador está mirando hacia el fantasma
        if (ghost != null)
        {
            Vector2 dir = ghost.transform.position - transform.position;
            if (Vector2.Dot(dir.normalized, transform.right) < 0f)
            {
                // El jugador no está mirando hacia el fantasma
            }
            else
            {
                // El jugador está mirando hacia el fantasma
            }
        }
    }

    void Move()
    {
        // Calcular la posición objetivo basada en la dirección
        Vector2 targetPos = rb2d.position + input;
        // Mover al personaje usando el Rigidbody2D y la velocidad
        rb2d.MovePosition(Vector2.MoveTowards(rb2d.position, targetPos, speed * Time.deltaTime));
        
    }
}
