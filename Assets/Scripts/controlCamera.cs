using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCamera : MonoBehaviour
{
    public GameObject objeto;
    private Vector3 posicion;
    public float adelante;
    public float Smoothing;
   

    // Update is called once per frame
    void Update()
    {
        posicion = new Vector3(objeto.transform.position.x,objeto.transform.position.y,transform.position.z);

        if (objeto.transform.localScale.x == 1)
        {
            posicion = new Vector3(posicion.x + adelante,posicion.y,transform.position.z);
        }

        if (objeto.transform.localScale.x == -1)
        {
            posicion = new Vector3(posicion.x - adelante, posicion.y, transform.position.z);
            
        }

        transform.position = Vector3.Lerp(transform.position, posicion, Smoothing * Time.deltaTime);

    }



}
