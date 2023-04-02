using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasStart : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}

