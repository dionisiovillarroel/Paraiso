using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorDiario : MonoBehaviour
{
    [SerializeField]
    private GameObject ayudaAgarrar;
    [SerializeField]
    private GameObject ayudaDescartar;
    [SerializeField]
    private Transform  posicionDeAgarreDiario;
    private GameObject diarioAgarrado;

    [SerializeField]
    private LayerMask layersAfectadas;
    private RaycastHit raycastHit;
    

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, 2f, layersAfectadas.value))
        {
            ayudaAgarrar.SetActive(true);
            if (Input.GetButton("Fire1"))
            {
                diarioAgarrado = raycastHit.collider.gameObject;
                raycastHit.collider.enabled = false;
                diarioAgarrado.GetComponent<Animator>().enabled = false;
                diarioAgarrado.GetComponent<AudioSource>().enabled = false;
                diarioAgarrado.transform.SetParent(this.transform);
                diarioAgarrado.transform.localPosition = posicionDeAgarreDiario.localPosition;
                diarioAgarrado.transform.localRotation = posicionDeAgarreDiario.localRotation;
                ayudaDescartar.SetActive(true);
                ayudaAgarrar.SetActive(false);
            }
        }
        else
        {
            if (diarioAgarrado != null)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Destroy(diarioAgarrado);
                    ayudaDescartar.SetActive(false);
                    diarioAgarrado = null;
                }
            }
            else
            {
                ayudaAgarrar.SetActive(false);
            }
        }
    }
}
