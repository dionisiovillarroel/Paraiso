using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoConstante : MonoBehaviour
{
    [SerializeField]
    private Vector3 movimiento;

    private Transform miTransform;

    private void Awake()
    {
        miTransform = transform;
    }

    private void Update()
    {
        miTransform.Translate(movimiento * Time.deltaTime);
    }
}
