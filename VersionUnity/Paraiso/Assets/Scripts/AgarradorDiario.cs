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
    private Diario     diarioAgarrado;

    [SerializeField]
    private LayerMask layersAfectadas;
    private RaycastHit raycastHit;

    private bool puedeSoltar = true;

    private bool puedeAgarrar = true;


    public void SoltarDiario(Diario diario)
    {
        if (diario == diarioAgarrado)
        {
            ayudaDescartar.SetActive(false);
            diarioAgarrado = null;
        }
    }

    public void DesactivarTeclaSoltar()
    {
        ayudaDescartar.SetActive(false);
        puedeSoltar = false;
    }

    void Update()
    {
        if (puedeAgarrar)
        {
            if (Physics.Raycast(transform.position, transform.forward, out raycastHit, 2f, layersAfectadas.value))
            {
                if (diarioAgarrado == null)
                {
                    ayudaAgarrar.SetActive(true);
                    if (Input.GetButton("Fire1"))
                    {
                        puedeAgarrar = false;
                        diarioAgarrado = raycastHit.collider.GetComponent<Diario>();
                        diarioAgarrado.transform.SetParent(this.transform);
                        diarioAgarrado.transform.localPosition = posicionDeAgarreDiario.localPosition;
                        diarioAgarrado.transform.localRotation = posicionDeAgarreDiario.localRotation;
                        diarioAgarrado.alActivar?.Invoke();
                        ayudaAgarrar.SetActive(false);
                        ayudaDescartar.SetActive(true);
                    }
                }
            }
            else if (puedeSoltar)
            {
                if (diarioAgarrado != null)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        diarioAgarrado.alDesechar?.Invoke();
                        Destroy(diarioAgarrado.gameObject);
                        ayudaDescartar.SetActive(false);
                        diarioAgarrado = null;
                        puedeAgarrar = false;
                    }
                }
                else
                {
                    ayudaAgarrar.SetActive(false);
                }
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            puedeAgarrar = true;
        }
    }
}
