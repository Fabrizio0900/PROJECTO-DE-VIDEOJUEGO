using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
   //Variable para asignar la velocidad
    public float velocidad;
    public float fuerzaSalto;
    public int saltosMaximos;
    public LayerMask capaSuelo;
    

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = true;
    private int saltosRestantes;
    private Animator animator;

    private void Start() {

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

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x,boxCollider.bounds.size.y),0f,Vector2.down,0.2f,capaSuelo);
        return raycastHit.collider != null;
        
    }

    void ProcesarSalto()
    {
        if(EstaEnSuelo())
        {
            saltosRestantes=saltosMaximos;
        }
        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,0f);
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

    }
    void ProcesarMovimiento()
    {

        //Logica de Movimiento
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

        //Si se cumple la orientacion
        if((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0))
        {
             //Ejecutar codigo de volteado
             mirandoDerecha = !mirandoDerecha;
             transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);

        }
    }
}
