using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float stoppingDistance = 3f;
    public float retreatDistance = 5f;
    public Vector3 startingPosition;

    Animator animator;
    public RuntimeAnimatorController controller1;
    public RuntimeAnimatorController controller2;
    private Transform playerPos;
    private MainCharacter playerObj;
    private Rigidbody2D rb2d;
    float retreatTime=0f;
    public bool canMove;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter>();
        rb2d = GetComponent<Rigidbody2D>();
        startingPosition= rb2d.position;
        animator = GetComponent<Animator>();
        int rand = Random.Range(0, 2);
        if(rand == 0)
            animator.runtimeAnimatorController = controller1;
        else
            animator.runtimeAnimatorController = controller2;

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
                Animation(direction);

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
            retreatTime += Time.deltaTime;
            if(retreatTime > 5f)
            {
                if (Vector2.Distance(transform.position, startingPosition) < 0.2f)
                {
                    rb2d.velocity = Vector2.zero;
                    retreatTime = 0f;
                }
                else
                {
                    Vector2 direction = (startingPosition - transform.position).normalized;
                    rb2d.velocity = direction * moveSpeed;
                }
                
            }
            else
            {
                rb2d.velocity = Vector2.zero;
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
    void Animation(Vector2 distance)
    {
        float posx=Mathf.Abs(distance.x);
        float posy=Mathf.Abs(distance.y);

        if(posx<posy)
        {
            if(distance.y < 0)
            {
                animator.SetFloat("moveY", -1);
                animator.SetFloat("moveX", -1);
            }
            else
            {
                animator.SetFloat("moveY", 1);
                animator.SetFloat("moveX", 1);
            }
            
        }else
        {
            if(distance.x<0)
            {
                animator.SetFloat("moveX", -1);
                animator.SetFloat("moveY", 1);
            }
            else
            {
                animator.SetFloat("moveX", 1);
                animator.SetFloat("moveY", -1);
            }
        }
    }
}
