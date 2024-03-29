using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statues : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
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
    public GameObject startingPosition;
    Vector3 startPos;
    public bool isAttacking=true;
    public float contador=0f;
    public GameObject textoMoney;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter>();
        moveTimer = 0f;
        startPos=startingPosition.GetComponent<Rigidbody2D>().position;
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
                if (distanceToPlayer > 0.2f&&isAttacking)
                {
                    Vector2 direction = (objetivo.position - transform.position).normalized;
                    rigidbody2D.velocity = direction * moveSpeed;
                }
                else
                {
                    if(isAttacking)
                    {
                        rigidbody2D.velocity = Vector2.zero;
                    }
                    
                    contador=contador+Time.deltaTime;
                    isAttacking = false;
                    if(contador>5f)
                    {/* 
                        //float distanceToBase = Vector2.Distance(transform.position, startingPosition);
                        if(Vector2.Distance(transform.position,startPos)>0.2f)
                        {
                            Vector2 direction = (startPos - transform.position).normalized;
                            rigidbody2D.position = startPos;
                        }
                        else
                        {
                            contador = 0f;
                            canMove=false;
                            rigidbody2D.velocity=Vector2.zero;
                        }*/
                        rigidbody2D.position = startPos;
                        textoMoney.SetActive(false);
                        contador = 0f;
                        canMove = false;
                        isAttacking = true;
                    }
                        
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

                // Si se presiona una direcci�n, mover al personaje
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
            int amount = Random.Range(50, 300);
            playerObj.GetMoney(-amount);
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
        // Calcular la posici�n objetivo basada en la direcci�n
        Vector2 targetPos = rigidbody2D.position + input;
        // Mover al personaje usando el Rigidbody2D y la velocidad
        rigidbody2D.MovePosition(Vector2.MoveTowards(rigidbody2D.position, targetPos, speed * Time.deltaTime));
    }
}
