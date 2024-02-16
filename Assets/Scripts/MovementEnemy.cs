using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovementEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidadMovimiento;
    public float distancia;
    private Animator animator;
    public float tiempoCambio;
    private float tiempoRestante;
    public float tiempoEnfriamientoAtaque = 1f; 
    private float tiempoProximoAtaque = 0f;
    public float damage = 10f;
    private bool mirandoDerecha = true;
    public Transform jugador;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tiempoRestante = tiempoCambio;
        jugador = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(velocidadMovimiento * transform.right.x, rb.velocity.y);
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);


        if (distanciaJugador <= distancia)
        {
            // El enemigo ataca
            Atack();
        }
        else
        {
            // Si no, el enemigo sigue moviéndose
            rb.velocity = new Vector2(velocidadMovimiento * transform.right.x, rb.velocity.y);
        }



        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            Girar();
            tiempoRestante = tiempoCambio;
        }






    }

    void Girar()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    void Atack()
    {
        if (Time.time >= tiempoProximoAtaque)
        {
            
            jugador.GetComponent<VidaPlayer>().TakeDamage(damage);

           
            tiempoProximoAtaque = Time.time + tiempoEnfriamientoAtaque;
        }

        jugador.GetComponent<VidaPlayer>().TakeDamage(damage);
    }

    public void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

}






