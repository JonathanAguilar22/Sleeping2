using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision) //Cuando se choque con el item, se activa un sonido y se añaden 15 puntos
                                                        //al personaje
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.recuperarVida();
            Destroy(this.gameObject);

        }
    }
}
