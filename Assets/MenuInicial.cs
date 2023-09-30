using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuInicial : MonoBehaviour
{
    public VideoPlayer intro;
    public GameObject menuInicial;
    public GameObject fondoNegro;

    private void Awake()
    {
        fondoNegro.SetActive(true); 
        menuInicial.SetActive(false);
        intro = GetComponent<VideoPlayer>();
        intro.Play();
        intro.loopPointReached += PasarMenu;
    }

    void PasarMenu(VideoPlayer vp)
    {
        gameObject.SetActive(false);
        fondoNegro.SetActive(false);
        menuInicial.SetActive(true);
    }

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
