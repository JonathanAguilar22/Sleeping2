using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI puntos;

    public GameObject[] vidas;
    void Update() // Muestra los puntos en forma de texto en la pantalla
    {
        puntos.text = gameManager.PuntosTotales.ToString();
    }

    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text = puntosTotales.ToString();
    }

    public void DesactivarVidas(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }



}

