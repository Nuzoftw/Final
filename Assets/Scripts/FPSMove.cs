using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMove : FPSAim
{
    public float speed = 0.1f;
    // Cada uno de los si condicionales hace que el jugador se mueva hacia adelante, atras, a la derecha y a la izquierda.
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed;
        }
        gira();
    }
}

