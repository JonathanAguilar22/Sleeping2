using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public GameManager gameManager;
    public CharacterMovement character;
    public Audiomanager audioManager;
    public AudioClip item;

    private void OnTriggerEnter2D(Collider2D collision) //Cuando se choque con el item, se activa un sonido y se añaden 15 puntos
                                                        //al personaje
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.perderVida();
            character.aplicarGolpe();
            audioManager.ReproducirSonido(item);
        }
    }
}
