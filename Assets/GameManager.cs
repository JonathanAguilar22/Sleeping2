using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _puntosTotales;

    public HUD hud;

    public int PuntosTotales { get { return _puntosTotales; } }

    public int vidas = 3;


    public void SumarPuntos(int puntosASumar)
    {
        _puntosTotales += puntosASumar;
        hud.ActualizarPuntos(PuntosTotales);
    }

    public void perderVida()
    {
        vidas -= 1;
        hud.DesactivarVidas(vidas);

    }

    public void recuperarVida()
    {
        if (vidas == 3)
        {
            return;
        }
        hud.ActivarVida(vidas);
        vidas += 1;
    }
}
