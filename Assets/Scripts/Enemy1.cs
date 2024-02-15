using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float vida;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0f)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
    }

    
    public void AnimacionMuerteFinalizada()
    {
        Destroy(gameObject);
    }
}
