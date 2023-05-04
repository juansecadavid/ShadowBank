using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statues : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private MainCharacter playerObj;
    public Transform objetivo;
    public bool canMove=false;
    public float moveSpeed;
    public bool IsToMove;
    private Vector2 input;
    float moveTimer;
    float speed;
    float speedInicial;
    float moveDelay;
    BoxCollider2D boxCol;
    public GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter>();
        moveTimer = 0f;
        speed= playerObj.speed;
        speedInicial = playerObj.speedInicial;
        moveDelay = playerObj.moveDelay;
        boxCol=GetComponent<BoxCollider2D>();
        if(IsToMove)
        {
            boxCol.isTrigger = false;
            canMove = false;
            child.SetActive(false);
        }
        else
            boxCol.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(!IsToMove)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, objetivo.position);
            if (canMove)
            {
                if (distanceToPlayer > 0.2f)
                {
                    Vector2 direction = (objetivo.position - transform.position).normalized;
                    rigidbody2D.velocity = direction * moveSpeed;
                }
                else
                {
                    rigidbody2D.velocity = Vector2.zero;
                }

            }
        }
        else
        {
            if(Input.GetKey(KeyCode.E)&&canMove)
            {
                rigidbody2D.mass = 1f;
                // Obtener entradas de teclado
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");
                if (Input.GetKey(KeyCode.LeftShift))
                    speed = speedInicial + 2;
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

                // Si se presiona una dirección, mover al personaje
                if (input != Vector2.zero && moveTimer <= 0f)
                {
                    Move();
                    moveTimer = moveDelay;
                }
            }
            else
            {
                input = Vector2.zero;
                Move();
                rigidbody2D.mass = 3000000f;
            }

            // Actualizar el temporizador de movimiento
            if (moveTimer > 0f)
            {
                moveTimer -= Time.deltaTime;
            }
        
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerObj.ChangeFear(3);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            canMove = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            canMove = false;
        }
    }
    void Move()
    {
        // Calcular la posición objetivo basada en la dirección
        Vector2 targetPos = rigidbody2D.position + input;
        // Mover al personaje usando el Rigidbody2D y la velocidad
        rigidbody2D.MovePosition(Vector2.MoveTowards(rigidbody2D.position, targetPos, speed * Time.deltaTime));
    }
}
