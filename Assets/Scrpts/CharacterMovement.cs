using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    //Variables utilizadas para movimiento 
    public float Velocidad;
    public bool mirandoDerecha = true;
    public LayerMask capaSuelo;

    //Variable para daño 
    private float fuerzaGolpe = 800;
    private bool puedeMoverse = true;

    //Variables usadas para sonido
    public Audiomanager audioManager;
    public AudioClip jump;
    public AudioClip lose;
    public AudioClip soundtrack;


    //Variables usadas para los saltos
    private float fuerzaSalto = 15;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private float saltosMax = 2f;
    private float saltosRestantes;
    private Animator animator;

    //Variable usadas para el cambio de estado del juego
    public GameObject pantallaPausa;
    public GameObject pantallaGameOver;
    public GameManager GameManager;

    public Estados estado;
    bool escPulsada;

    //Llamada a funciones
    void Update()
    {
        
        if(estado==Estados.Juego)
        {
            ProcessMovement();
            processJump();
            if (Input.GetKeyDown(KeyCode.Escape) && !escPulsada)
            {
                escPulsada = true;
                Pausa();
            }
            if(GameManager.vidas<=0)
            {
                estado = Estados.GameOver;
            }
        }
        if (!Input.GetKeyDown(KeyCode.Escape))
            escPulsada = false;
        if (estado == Estados.GameOver)
        {
            GameOver();
        }
    }

    //Funcion de comienzo que obtiene todos los componentes y los almacena en una variable 
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        saltosRestantes = saltosMax;

        pantallaPausa.SetActive(false);
        pantallaGameOver.SetActive(false);
        escPulsada = false;
        estado = Estados.Juego;
    }


    //Esta variable verifica si el personaje está en el suelo y retorna un booleano
    bool EstaEnSuelo()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return hit.collider != null;

    }


    void ProcessMovement()
    {

        if (!puedeMoverse) return;

        float inputMovement = Input.GetAxis("Horizontal"); //Se obtienen los valores de las teclas en el eje x

        if (inputMovement != 0f) //Si la variable de movimiento es diferente de 0 
        {
            animator.SetBool("isRunning", true); //Se realizará la animación
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(inputMovement * Velocidad, rigidbody.velocity.y);
        ChangeDirection(inputMovement);

    }


    void processJump()
    {

        if (EstaEnSuelo()) //Si está en el suelo, se reinician los saltos restantes
        {
            saltosRestantes = saltosMax;

        }

        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0) //Si se presiona la tecla de espacio y aún quedan saltos
        {
            saltosRestantes--; //a los saltos se les resta 1
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            audioManager.ReproducirSonido(jump); //se reproduce sonido
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse); //se añade fuerza al rigidbody 
        }
    }



    void ChangeDirection(float inputMovement) //Cambia la dirección del personaje y la animación S
    {

        if ((mirandoDerecha == true && inputMovement < 0) || (mirandoDerecha == false && inputMovement > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }



    public void aplicarGolpe()
    {
        Vector2 direccionGolpe;
        puedeMoverse = false;

        if (rigidBody.velocity.x > 0)
        {
            direccionGolpe = new Vector2(-1, 1);
        }
        else
        {
            direccionGolpe = new Vector2(1, 1);
        }
        rigidBody.AddForce(direccionGolpe * fuerzaGolpe);
        StartCoroutine(EsperaYActivaMovimiento());

    }

    IEnumerator EsperaYActivaMovimiento()
    {
        yield return new WaitForSeconds(0.1f);

        while (!EstaEnSuelo())
        {
            yield return null;
        }

        puedeMoverse = true;
    }

    //Activa el menu de pausa y paraliza el juego
    public void Pausa()
    {
        pantallaPausa.SetActive(true); 
        Time.timeScale = 0f;
    }

    //Permite salir del menu de pausa
    public void Continuar()
    {
        pantallaPausa.SetActive(false); 
        Time.timeScale = 1f;
    }

    //Activa la pantalla de GameOver
    public void GameOver()
    {
        pantallaGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    //Se reinicia el nivel actual
    public void Reiniciar()
    {
        pantallaGameOver.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Esta funcion permite cambiar de escena para regresar al menu principal
    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }

    public enum Estados
    {
        Juego,
        GameOver
    }
}