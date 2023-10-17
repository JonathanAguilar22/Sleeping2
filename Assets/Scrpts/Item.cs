using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int valor = 1; //Valor del item
    public GameManager gameManager;
    public Audiomanager audioManager;
    public AudioClip item;

    private void OnTriggerEnter2D(Collider2D collision) //Cuando choque con el item, se sumará el punto y a su vez 
    {                                                   //se destruye o desaparece el item
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
            audioManager.ReproducirSonido(item);
        }
    }
}
