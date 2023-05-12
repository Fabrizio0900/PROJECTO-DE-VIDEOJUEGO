using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public int saltosMaximos;
    public LayerMask capaSuelo;
    public AudioClip sonidoSalto;

    private int saltosRestantes;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = true;
    private Animator animator;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y),0f,Vector2.down,0.2f,capaSuelo);
        return raycastHit.collider != null;
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("w"))
        {
            if (saltosRestantes >= 1)
            {
                    saltosRestantes--;
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
                    rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                    AudioManager.Instance.ReproducirSonido(sonidoSalto);
            }
            else
            {
                    if (EstaEnSuelo())
                    {
                        saltosRestantes = saltosMaximos;
                        animator.SetBool("isJumping", false);
                    }
                    else
                    {
                        animator.SetBool("isJumping", true);
                    }
            }
        }
    }

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");

        if(inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        
        rigidBody.velocity = new Vector2(inputMovimiento*velocidad,rigidBody.velocity.y);

        GestionarOrientacion(inputMovimiento);
    }

    void GestionarOrientacion(float inputMovimiento)
    {
        if((mirandoDerecha==true && inputMovimiento < 0) || (mirandoDerecha==false && inputMovimiento > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
