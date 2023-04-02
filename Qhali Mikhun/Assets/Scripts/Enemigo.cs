using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public AudioClip sonidoEnemigo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.PerderVida();
            Destroy(this.gameObject);
            AudioManager.Instance.ReproducirSonido(sonidoEnemigo);
                
        }
    }
}
