using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSAim : MonoBehaviour
{
    // Los "si" condicionales son los que se encargan del movimiento del mouse, positivo y negativo, tanto horizontal como verticalmente,
    // y el método "gira" es el que contiene el vector que se encarga de girarlo tanto vertical como horizontalmente.
    float x;
    float y;
    public bool invertemouse;

    void Update()
    {
        if (invertemouse)
        {
            y += Input.GetAxis("Mouse Y");
        }
        else
        {
            y -= Input.GetAxis("Mouse Y");
        }
        gira();
    }
    public void gira()
    {
        x += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(y, x, 0);
    }
}
