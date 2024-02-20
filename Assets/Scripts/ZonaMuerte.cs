using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaMuerte : MonoBehaviour
{
    
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="DeathZone")
        {
            animator.SetTrigger("Death");
            Debug.Log("muerte");
        }
        
    }
}
