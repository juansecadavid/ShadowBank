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
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, objetivo.position);
        if (canMove)
        {
            if(distanceToPlayer > 0.2f)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerObj.ChangeFear(3);
        }
    }
    void Die()
    {

    }
}
