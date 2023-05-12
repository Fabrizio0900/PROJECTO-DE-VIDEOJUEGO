using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasStart : MonoBehaviour
{
    public GameObject menuInfo;
    public GameObject menuControles;

    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    } 
    public void Ayuda()
    {
        menuInfo.SetActive(true);
    }
    public void CerrarAyuda()
    {
        menuInfo.SetActive(false);
    }
    public void Controles()
    {
        menuControles.SetActive(true);
    }
    public void CerrarControles()
    {
        menuControles.SetActive(false);
    }
}

