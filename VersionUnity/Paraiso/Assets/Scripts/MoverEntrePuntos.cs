using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoverEntrePuntos : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField]
    private Transform[] posiciones;

    [Header("Propiedades")]
    [SerializeField]
    private bool      loopea = false;
    [SerializeField]
    private float     velocidad;

    private int       indiceActual = 0;
    private Transform miTransform;

    [SerializeField]
    private UnityEvent alTerminarMovimiento;

    private void Start()
    {
        miTransform = transform;
        StartCoroutine(Mover());
    }

    private IEnumerator Mover()
    {
        while (indiceActual < posiciones.Length)
        {
            while (miTransform.position != posiciones[indiceActual].position)
            {
                miTransform.position = Vector3.MoveTowards(miTransform.position, posiciones[indiceActual].position, velocidad * Time.deltaTime);
                yield return null;
            }
            indiceActual++;
            if (indiceActual >= posiciones.Length && loopea) indiceActual = 0;
        }
        alTerminarMovimiento?.Invoke();
    }
}
