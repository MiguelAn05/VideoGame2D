using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour
{
    public float vida;
    public Transform controladorGolpe;
    public float radioGolpe;
    public float dañoGolpe;
    public float tiempoEntreAtaques;
    public float tiempoSiguienteAtaque;

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (tiempoEntreAtaques > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.J) && tiempoSiguienteAtaque<=0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }




    public void DamagePlayer(float damage)
    {
        vida -= damage;
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("Atack1");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)

        {
            if (colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.GetComponent<Enemy1>().TomarDaño(dañoGolpe);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe); 
    }
}
