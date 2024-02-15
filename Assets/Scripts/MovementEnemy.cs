using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidadMovimiento;
    public float distancia;
    
    public float tiempoCambio;
    private float tiempoRestante;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tiempoRestante = tiempoCambio;
    }

    private void Update()
    {
        rb.velocity = new Vector2(velocidadMovimiento * transform.right.x, rb.velocity.y);

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

    


}
