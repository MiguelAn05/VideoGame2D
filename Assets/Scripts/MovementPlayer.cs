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
    public float walk;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal")*speed;
        animator.SetFloat("speed",speed);
    }

    private void FixedUpdate()
    {
        Mover(movimientoHorizontal * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
           
    }

    private void Mover(float mover) {
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
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala; 
    }
}
