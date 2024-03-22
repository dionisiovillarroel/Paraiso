using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEntrePuntos : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField]
    private Transform[] posiciones;

    [Header("Propiedades")]
    [SerializeField]
    private float     velocidad;

    private int       indiceActual = 0;
    private Transform miTransform;

    private void Awake()
    {
        miTransform = transform;
        StartCoroutine(Mover());
    }

    private IEnumerator Mover()
    {
        while (true)
        {
            while (miTransform.position != posiciones[indiceActual].position)
            {
                miTransform.position = Vector3.MoveTowards(miTransform.position, posiciones[indiceActual].position, velocidad * Time.deltaTime);
            }
            indiceActual++;
            if (indiceActual >= posiciones.Length) indiceActual = 0;
        }
    }
}
