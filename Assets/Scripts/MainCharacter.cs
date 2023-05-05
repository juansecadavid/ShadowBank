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
    float lightTime = 0f;
    bool canUseLintern;
    public TextMeshProUGUI moneyText;
    private float contadorDinero = 0;

    private Rigidbody2D rb2d; // Componente Rigidbody2D del personaje
    private Vector2 input; // Almacenar� las entradas del jugador
    private float moveTimer = 0f; // Timer para el retraso entre movimientos
    public float levelLight;
    Animator anim;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        animationTime = fearBar / 60f;
        fearText.text = $"{fearBar}";
        worldLight.intensity = levelLight;
    }
    private void Update()
    {
        HearthBit();
        fearText.text = $"{fearBar}";
        animationTime = 60f/fearBar-0.3f;
        lightTime+=Time.deltaTime;
        moneyText.text = $"{contadorDinero}";
        if(lightTime>10f)
        {
            int generator = Random.Range(0, 2);
            if(generator == 0)
            {
                canUseLintern = false;
            }
            else
            {
                canUseLintern= true;
            }
            lightTime = 0f;
        }
        if(Input.GetKey(KeyCode.F)&&canUseLintern)
        {
            lintern.SetActive(true);
        }
        else
            lintern.SetActive(false);
        Die();
        Color color = new Color();
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

            // Si se presiona una direcci�n, mover al personaje
            if (input != Vector2.zero && moveTimer <= 0f)
            {
                Move();
                float angle = Mathf.Atan2(-input.x, input.y) * Mathf.Rad2Deg;
                catcher.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                moveTimer = moveDelay;
            }else
            {
                anim.SetBool("IsWalking", false);
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

        if (input.x > 0f)
        {
            anim.SetFloat("X", 1);
            anim.SetFloat("Y", 0);
            anim.SetBool("IsWalking", true);
        }
        else if (input.x < 0f)
        {
            anim.SetFloat("X", -1);
            anim.SetFloat("Y", 0);
            anim.SetBool("IsWalking", true);
        }
        else if (input.y > 0f)
        {
            anim.SetFloat("Y", 1);
            anim.SetFloat("X", 0);
            anim.SetBool("IsWalking", true);
        }
        else if (input.y < 0f)
        {
            anim.SetFloat("Y", -1);
            anim.SetFloat("X", 0);
            anim.SetBool("IsWalking", true);
        }

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
    void Die()
    {
        if (fearBar>190)
        {
            gameObject.SetActive(false);
        }
    }
    public void GetMoney(float amount)
    {
        contadorDinero += amount;
        if(contadorDinero<0)
        {
            contadorDinero = 0;
        }
    }
}
