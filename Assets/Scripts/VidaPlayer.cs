using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public float vida;
    public float maximoVida;
    public BarraDeVida barraDeVida;



    private void Start()
    {
        vida = maximoVida;
        barraDeVida.InicializarBarraVida(vida);

    }

    public void TakeDamage(float damage)
    {
        vida -= damage;
        barraDeVida.CambiarVidaActual(vida);
        if(vida<= 0)
        {
            Destroy(gameObject);
        }
    }


}
