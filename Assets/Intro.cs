using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Audio;

public class Intro : MonoBehaviour
{
    //Se declaran variables que se van a usar en la escena "intro"
    public VideoPlayer intro;
    public GameObject fondoNegro;

    //En esta funcion se dan valores iniciales al iniciar la escena
    private void Awake()
    {
        fondoNegro.SetActive(true); //Se activa una imagen negra, esto para que al escalar la pantalla no se vea mal el video de intro
        intro = GetComponent<VideoPlayer>();  //Se obtiene el video que se va a reproducir
        intro.Play(); //Se reproduce el video
        intro.loopPointReached += PasarMenu; //Cuando el video finaliza se llama a la funcion PasarMenu
    }

    //En esta funcion solo se cambia de escena cuando termina el video de intro, la escena a la que se cambia es el munu inicial
    void PasarMenu(VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }
}