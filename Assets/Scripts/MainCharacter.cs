using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public float speedInicial;
    public float speed = 5f; // Velocidad de movimiento del personaje
    public float moveDelay;  // Tiempo de retraso entre movimientos
    public bool canMove = true; // Indica si el jugador puede moverse
    public int fearBar;

    private Rigidbody2D rb2d; // Componente Rigidbody2D del personaje
    private Vector2 input; // Almacenar� las entradas del jugador
    private float moveTimer = 0f; // Timer para el retraso entre movimientos

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            // Obtener entradas de teclado
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (Input.GetKey(KeyCode.LeftShift))
                speed = speedInicial+10;
            else
                speed = speedInicial;
            // Restringir el movimiento en un solo eje
            if (Mathf.Abs(input.x) > 0f)
            {
                input.y = 0f;
            }
            else if (Mathf.Abs(input.y) > 0f)
            {
                input.x = 0f;
            }

            // Si se presiona una direcci�n, mover al personaje
            if (input != Vector2.zero && moveTimer <= 0f)
            {
                Move();
                float angle = Mathf.Atan2(-input.x, input.y) * Mathf.Rad2Deg;
                //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
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
    }

    void Move()
    {
        // Calcular la posici�n objetivo basada en la direcci�n
        Vector2 targetPos = rb2d.position + input;
        // Mover al personaje usando el Rigidbody2D y la velocidad
        rb2d.MovePosition(Vector2.MoveTowards(rb2d.position, targetPos, speed * Time.deltaTime));      
    }
}
