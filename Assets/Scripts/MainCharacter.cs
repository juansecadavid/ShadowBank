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
    public GameObject canvaDie;

    public GameObject barraEnergia;
    public GameObject portaPapeles;
    public GameObject iconPorta;
    public GameObject libroNotas;
    public GameObject iconLibro;
    public Light2D worldLight;
    float fearTime=0;
    public float animationTime;
    bool isVisible=true;
    public float lightTime = 0f;
    bool canUseLintern;
    public bool isNight;
    public TextMeshProUGUI moneyText;
    private float contadorDinero = 0;
    public bool canRun;
    private Rigidbody2D rb2d; // Componente Rigidbody2D del personaje
    private Vector2 input; // Almacenar� las entradas del jugador
    private float moveTimer = 0f; // Timer para el retraso entre movimientos
    public float levelLight;
    public float contadorEnergia;
    public float contadorLuz;
    private BarraEnergía barrita;
    Animator anim;
    public AudioClip latido;
    public AudioClip lightsOff;
    AudioSource audioSource;
    public TextMeshProUGUI textoPerdida;
    SoundManager soundManager;
    bool isPlaying;
    bool isPlayingFearSound;
    public GameObject audioSource2;
    public TextMeshProUGUI textoPildoras;
    int pildoras = 5;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        animationTime = fearBar / 60f;
        fearText.text = $"{fearBar}";
        worldLight.intensity = levelLight;
        textoPerdida.gameObject.SetActive(false);
        barrita=FindObjectOfType<BarraEnergía>();
        canUseLintern=true;
        soundManager=FindAnyObjectByType<SoundManager>();
        isPlaying = false;
        audioSource=GetComponent<AudioSource>();
        if(isNight)
        {
            barraEnergia.SetActive(false);
            lintern.SetActive(false);
            isPlayingFearSound=false;
            audioSource2.SetActive(false);
            textoPildoras.text = $"{pildoras}";
        }
    }
    private void Update()
    {
        HearthBit();
        fearText.text = $"{fearBar}";
        animationTime = 60f/fearBar-0.3f;
        moneyText.text = $"{contadorDinero}";
        if(isNight==false)
        {
            if(Input.GetKey(KeyCode.Tab))
            {
                portaPapeles.SetActive(true);
                iconPorta.SetActive(false);
                canMove = false;
            }
            else
            {
                portaPapeles.SetActive(false);
                iconPorta.SetActive(true);
                canMove = true;
            }
        }
        else
        {
            textoPildoras.text = $"{pildoras}";
            /*if (Input.GetKeyDown(KeyCode.Tab))
            {
                if(libroNotas.activeInHierarchy)
                {
                    libroNotas.SetActive(false);
                    iconLibro.SetActive(true);
                    canMove = true;
                }
                else
                {
                    libroNotas.SetActive(true);
                    iconLibro.SetActive(false);
                    canMove = false;
                }             
            }*/
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(pildoras>0)
                {
                    pildoras--;
                    fearBar -= 30;
                }
            }
        }
        
        
        if(Input.GetKeyDown(KeyCode.F)&&canUseLintern)
        {
            if(lintern.activeInHierarchy)
            {
                lintern.SetActive(false);
            }
            else
            {
                lintern.SetActive(true);
            }
            
        }
        else if(!canUseLintern)
            lintern.SetActive(false);

        if(lintern.activeInHierarchy)
        {
            lightTime += Time.deltaTime;
        }
        else if(!lintern.activeInHierarchy&&!canUseLintern)
        {
            lightTime += Time.deltaTime;
        }
        if (lightTime > 10f)
        {
            float generator = Random.Range(0f, 1f);
            if (generator < 0.3f)
            {
                canUseLintern = false;
            }
            else
            {
                canUseLintern = true;
            }
            lightTime = 0f;
        }
        Die();
        
        LightsOFF();

    }
    void FixedUpdate()
    {
        if (canMove)
        {
            // Obtener entradas de teclado
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (Input.GetKey(KeyCode.LeftShift)&&canRun)
                {
                    speed = speedInicial+2;
                    barraEnergia.SetActive(true);
                    contadorEnergia=0f;
                }
            else
            {
                speed = speedInicial;
                ChangeEnergy(barrita);
            }
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
            //audioSource.clip = latido;
            isVisible = !isVisible;
            if (isVisible)
            {

            }
                //soundManager.SeleccionAudios(1, 0.1f);
            fearHeart.SetActive(isVisible);
            //soundManager.ControlAudio.Stop();
            //soundManager.SeleccionAudios(1,0.5f);
            if(!isPlayingFearSound&&isNight)
            {
                audioSource.Stop();
                audioSource.Play();
            }         
            fearTime = 0.0f;
        }
        if(!isPlayingFearSound&&fearBar>=180)
        {
            audioSource2.SetActive(true);
            isPlayingFearSound = true;
        }
        if(isPlayingFearSound&&fearBar<180)
        {
            audioSource2.SetActive(false);
            isPlayingFearSound=false;
        }
    }
    void Die()
    {
        if (fearBar>190)
        {
            gameObject.SetActive(false);
            canvaDie.SetActive(true);
        }
    }
    public void GetMoney(float amount)
    {
        contadorDinero += amount;
        if(amount<0)
        {
            textoPerdida.text = $"- {-amount}";
            textoPerdida.gameObject.SetActive(true);
        }
        if(contadorDinero<0)
        {
            contadorDinero = 0;
        }
    }

    public void ChangeEnergy(BarraEnergía barra)
    {
       if(isNight)
       {
          if(barra.barraEnergia<0)
            {
    
            }
          else
          {
             contadorEnergia+=Time.deltaTime;
             if(contadorEnergia>1f)
             {
                 barraEnergia.SetActive(false);
             }
          }
       }
       
    }
    
    public void LightsOFF()
    {  
        if(isNight)
        {
           contadorLuz+=Time.deltaTime;
           if(contadorLuz>60f&&contadorLuz<62f)
           {
              worldLight.intensity=0f;
              if(isPlaying==false)
              {
                    soundManager.SeleccionAudios(0,0.5f);
                    isPlaying =true;
              }
    
            }
            else if(contadorLuz>74f)
            {
                  contadorLuz=0f;
                  worldLight.intensity=0.2f;
                  isPlaying=false;
            }
        }
    }
}
