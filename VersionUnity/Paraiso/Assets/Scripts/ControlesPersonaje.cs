using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesPersonaje : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField]
    private Rigidbody miRigidbody;
    [SerializeField]
    private Transform transformDeCamara;

    private Vector3   inputMovimiento;
    private Vector3   inputRotacion;

    [Header("Parámetros")]
    [SerializeField]
    private float     velocidadDeMovimiento;
    [SerializeField]
    private float     velocidadDeRotacion;

    private void Start()
    {
        inputMovimiento.y = 0f;
        inputRotacion.z   = 0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        inputMovimiento.z = Input.GetAxis("Vertical");
        inputMovimiento.x = Input.GetAxis("Horizontal");
        if (inputMovimiento.sqrMagnitude > 1f) inputMovimiento.Normalize();
        miRigidbody.velocity = (transform.forward * inputMovimiento.z + transform.right * inputMovimiento.x) * velocidadDeMovimiento;

        inputRotacion.y = Input.GetAxis("Mouse X");
        inputRotacion.x = -Input.GetAxis("Mouse Y");
        miRigidbody.angularVelocity = Vector3.up * inputRotacion.y * velocidadDeRotacion;

        transformDeCamara.localRotation *= Quaternion.Euler(Vector3.right * inputRotacion.x * velocidadDeRotacion);
    }
}
