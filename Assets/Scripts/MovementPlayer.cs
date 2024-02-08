using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Animator animator;
    private float movimientoHorizontal;
    public float speed;
    public float suavizadoMovimiento;
    private Rigidbody2D rb;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    public float fuerzaDeSalto;
    public LayerMask suelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    private bool floor;
    private bool salto = false;
    public float distanciaAlSuelo = 0.1f;



    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal")*speed;
        animator.SetFloat("speed",speed);

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        {
            floor = Physics2D.Raycast(controladorSuelo.position, -Vector2.up, distanciaAlSuelo, suelo);

            Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                animator.SetBool("Walking", true);
            }
            else
            {
                animator.SetBool("Walking", false);
            }
        }


    }


    
    


    private void Mover(float mover,bool saltar) {
        Vector3 velocidadObjetivo = new Vector2(mover, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        } 

        else if(mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        if(floor && saltar)
        {
            floor = false;
            rb.AddForce(new Vector2(0f, fuerzaDeSalto));
            salto = false;
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala; 
    }
}
