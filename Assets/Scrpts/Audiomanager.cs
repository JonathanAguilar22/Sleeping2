using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se usa el componente de tipo audiosource para ejecutar archivos de audio
[RequireComponent(typeof(AudioSource))]
public class Audiomanager : MonoBehaviour
{
    private AudioSource audioSource; //Variable para almacenar el audio 

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //Obtener el audio y guardar en la variable audioSource
    }

    public void ReproducirSonido(AudioClip audio) //Función para reproducir sonido
    {
        audioSource.PlayOneShot(audio);

    }
}
