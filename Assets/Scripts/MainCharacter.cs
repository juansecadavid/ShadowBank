using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.U2D;
using UnityEngine.Rendering.Universal;

public class MainCharacter : MonoBehaviour
{
    public float speedInicial;
    public float speed = 5f; // Velocidad de movimiento del personaje
    public float moveDelay;  // Tiempo de retraso entre movimientos
    public bool canMove = true; // Indica si el jugador puede moverse
    public int fearBar;
    public TextMeshProUGUI fearText;
    public GameObject fearHeart;
    public GameObject catcher;
    public GameObject lintern;
    public Light2D worldLight;
    float fearTime=0;
    public float animationTime;
    bool isVisible=true;

    private Rigidbody2D rb2d; // Componente Rigidbody2D del personaje
    private Vector2 input; // Almacenará las entradas del jugador
    private float moveTimer = 0f; // Timer para el retraso entre movimientos

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animationTime = fearBar / 60f;
        fearText.text = $"{fearBar}";
        worldLight.intensity = 1f;
    }
    private void Update()
    {
        HearthBit();
        fearText.text = $"{fearBar}";
        animationTime = 60f/fearBar-0.3f;
        if(Input.GetKey(KeyCode.F))
        {
            lintern.SetActive(true);
        }
        else
            lintern.SetActive(false);
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            // Obtener entradas de teclado
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (Input.GetKey(KeyCode.LeftShift))
                speed = speedInicial+2;
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
                float angle = Mathf.Atan2(-input.x, input.y) * Mathf.Rad2Deg;
                catcher.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
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
        // Calcular la posición objetivo basada en la dirección
        Vector2 targetPos = rb2d.position + input;
        // Mover al personaje usando el Rigidbody2D y la velocidad
        rb2d.MovePosition(Vector2.MoveTowards(rb2d.position, targetPos, speed * Time.deltaTime));      
    }
    public void ChangeFear(int amount)
    {
        fearBar = fearBar + amount;
    }
    void HearthBit()
    {
        fearTime+=Time.deltaTime;
        if(fearTime>animationTime)
        {
            isVisible = !isVisible;
            fearHeart.SetActive(isVisible);
            fearTime = 0.0f;
        }
    }
}
