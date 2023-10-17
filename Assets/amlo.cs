using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amlo : MonoBehaviour
{
    public GameManager gameManager;
    public Audiomanager audioManager;
    public AudioClip choque;
    public int valor = 15;

    private void OnTriggerEnter2D(Collider2D collision) //Cuando se choque con el item, se activa un sonido y se añaden 15 puntos
                                                        //al personaje
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
            audioManager.ReproducirSonido(choque);
        }
    }


}
