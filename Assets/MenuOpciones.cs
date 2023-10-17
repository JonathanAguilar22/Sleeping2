using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
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
}
