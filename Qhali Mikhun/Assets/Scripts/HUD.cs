using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HUD : MonoBehaviour
{
    public GameObject menuGameOver;
    public GameObject menuPause;
    public TextMeshProUGUI puntos;
    public GameObject[] vidas;
    public GameObject player;
    public AudioSource audioSource;
    public GameObject muteImage;

    void Update()
    {
        puntos.text = GameManager.Instance.PuntosTotales.ToString();
    }

    public void Sonido()
    {
        if(audioSource.mute!=true)
        {
            muteImage.SetActive(true);
            audioSource.mute = true;
        }
        else
        {
            muteImage.SetActive(false);
            audioSource.mute=false;
        }
    }
    public void CerarMenu()
    {
        menuPause.SetActive(false);
    }

    public void MostarMenu()
    {
        menuPause.SetActive(true);
    }

    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text = puntosTotales.ToString();
    }

    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
        if (indice <= 0)
        {
            player.SetActive(false);
            menuGameOver.SetActive(true);
        }
    }

    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}
