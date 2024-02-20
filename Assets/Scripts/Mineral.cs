using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    public GameObject objeto;
    public float puntos = 1;
    public Puntaje puntaje;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puntaje.SumarPuntos(puntos);
            Instantiate(objeto, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
