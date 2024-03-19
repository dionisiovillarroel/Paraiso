using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    [SerializeField]
    private Transform cuboInterno;

    [SerializeField]
    private float     cargaMaxima  = 5f;

    [SerializeField]
    private float     cargaActual  = 0f;

    [SerializeField]
    private float     escalaMaxima = 0.5f;

    public void Cargar()
    {
        cargaActual += Time.deltaTime;
        cuboInterno.localScale = Vector3.one * (Mathf.Clamp01(cargaActual / cargaMaxima) * escalaMaxima);
    }
}
