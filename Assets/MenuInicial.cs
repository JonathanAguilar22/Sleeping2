using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Audio;

public class MenuInicial : MonoBehaviour
{
    //Variables necesarias para cambiar de nivel
    public bool pasarNivel;
    public int indiceNivel;
    //Se declara una variable de tipo Audiomixer para controlar el volumen del juego
    [SerializeField] private AudioMixer audioMixer;

    public void PantallaCompleta(bool pantallaCompleta)
    {
        //Utiliza una entrada booleana para saber si se esta en pantalla completa o no
        Screen.fullScreen = pantallaCompleta;
    }

    public void CambiarVolumen(float volumen)
    {
        //Cambia el volumen al nivel que el jugador escoja en una barra dentro de la interfaz
        audioMixer.SetFloat("Volumen", volumen);
    }

    //Se tiene como parametro un entero determinado por cada boton del menuNivel, y cambiara de escena segun este entero 
    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }


    //Se tiene una unica funcion, es usada para el boton de salir
    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit(); //Termina la aplicacion
    }
}
