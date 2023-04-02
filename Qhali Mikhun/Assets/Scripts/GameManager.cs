using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public HUD hud;
    public int PuntosTotales { get; private set; }
    private int vidas = 3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de un Game Manager en escena!");
        }
    }

    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales += puntosASumar;
        hud.ActualizarPuntos(PuntosTotales);
    }

    public void PerderVida()
    {
        vidas -= 1;
        hud.DesactivarVida(vidas);
    }
}
