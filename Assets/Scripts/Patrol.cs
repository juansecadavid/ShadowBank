using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rigidbody2D;
    private Vector2 input;
    private float moveTimer = 0f;
    public GameObject catcher;
    public float moveDelay;
    public GameObject pared;
    public NPCState currentState;
    //public float stateDuration = 3f;
    private float stateTimer = 0f;
    public bool patrolInX;
    public bool canMove;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        SetState(currentState, 4f);
        if(patrolInX)
            currentState = NPCState.HorizontalMovement;
        else
            currentState = NPCState.VerticalMovement;
        pared.SetActive(false);
        canMove = true;
 
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer > 0f)
        {
            moveTimer -= Time.deltaTime;
        }

        if (stateTimer > 0f)
        {
            stateTimer -= Time.deltaTime;
            if (stateTimer <= 0f&&patrolInX)
            {
                int rand = Random.Range(0, 2);
                // Cambiar de estado automáticamente
                if (canMove == false)
                {
                    SetState(NPCState.Idle, 10f);
                }
                else if (rand < 0.7f)
                {
                    SetState(NPCState.HorizontalMovement, 4f);
                }
                else
                {
                    SetState(NPCState.Idle, 10f);
                }
            }
            else if(stateTimer <= 0f&& !patrolInX)
            {
                int rand = Random.Range(0, 2);
                // Cambiar de estado automáticamente
                if (rand == 0)
                {
                    SetState(NPCState.VerticalMovement, 4f);
                }
                else
                {
                    SetState(NPCState.Idle, 10f);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        // Si se presiona una dirección y no está en tiempo de espera, mover al NPC
        if (input != Vector2.zero && moveTimer <= 0f)
        {
            Vector2 targetPos = rigidbody2D.position + input;
            rigidbody2D.MovePosition(Vector2.MoveTowards(rigidbody2D.position, targetPos, speed * Time.deltaTime));
            float angle = Mathf.Atan2(-input.x, input.y) * Mathf.Rad2Deg + 90;
            if (patrolInX)
            {
                if (angle == 180)
                {
                    catcher.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
                else
                    catcher.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }

            else
            {
                if (angle == 180)
                    catcher.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                else
                    catcher.transform.rotation = Quaternion.Euler(new Vector3(180, 0, 0));
            }

            moveTimer = moveDelay;
            
            if(input.y < 0f)
            {
                animator.SetFloat("moveY", -1f);
            }
            else if(input.y>0f)
            {
                animator.SetFloat("moveY", 1f);
            }

            if(input.x<0f)
            {
                animator.SetFloat("moveX", -1f);
            }
            else if(input.x>0f)
            {
                animator.SetFloat("moveX", 1f);
            }
            if(input!=Vector2.zero)
            {
                animator.SetBool("isMoving", true);
            }
        }
    }

    private void SetState(NPCState newState, float stateDuration)
    {
        currentState = newState;
        stateTimer = stateDuration;
        int rand = Random.Range(0, 2);

        if (newState == NPCState.VerticalMovement)
        {
            input.x = 0f;
            if (rand == 0)
            {
                input.y = 1f;
                animator.SetFloat("moveY",1f);
                

            }      
            else
            {
                input.y = -1f;
                animator.SetFloat("moveY", -1f);
            }
                
            animator.SetFloat("moveX", 0f);
            animator.SetBool("isMoving", true);
        }
        else if (newState == NPCState.HorizontalMovement)
        {
            input.y = 0f;
            if (rand == 0)
            {
                input.x = 1f; 
                animator.SetFloat("moveX", 1f);
            }
                
            else
            {
                input.x = -1f;
                animator.SetFloat("moveX", -1f);
            }
            animator.SetFloat("moveY", 0f);
            animator.SetBool("isMoving", true);
        }
        else if (newState == NPCState.Idle)
        {
            input = Vector2.zero;
            animator.SetBool("isMoving", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentState == NPCState.VerticalMovement)
        {
            input.y = -(input.y);
        }
        else if (currentState == NPCState.HorizontalMovement)
        {
            input.x = -(input.x);
        }
    }
}
