using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ControladorEnemigos : MonoBehaviour

{
    private float minX, maxX, minY, maxY;
    public Transform[] puntos;
    public GameObject[] enemigos;
    public float tiempoEnemigos;
    private float tiempoSigEnemigo;

    private void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);

    }

    private void Update()
    {
        tiempoSigEnemigo += Time.deltaTime;

        if(tiempoSigEnemigo >= tiempoEnemigos)
        {
            tiempoSigEnemigo = 0;
            CrearEnemigo();
        }

    }

    void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAL = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(enemigos[numeroEnemigo], posicionAL, Quaternion.identity);
    }
       
}
