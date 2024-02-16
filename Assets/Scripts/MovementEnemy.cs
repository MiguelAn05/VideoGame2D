using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{


    public Transform controladorGolpe;
    public float radioGolpe;
    public float damage;
    public float tiempoEntreAtaques;
    public float tiempoSiguienteAtaque;
    public Transform player; // referencia al jugador

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (tiempoEntreAtaques > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        // Verificar la distancia entre el enemigo y el jugador
        if (Vector2.Distance(transform.position, player.position) <= radioGolpe)
        {
            // Si el tiempo entre ataques ha pasado, ataca al jugador
            if (tiempoSiguienteAtaque <= 0)
            {
                Golpe();
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("AtackEnemy1");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Player"))
            {
                colisionador.transform.GetComponent<VidaPlayer>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

}












