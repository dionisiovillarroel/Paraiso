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

    private bool puedeAgarrar = true;


    public void SoltarDiario(Diario diario)
    {
        if (diario == diarioAgarrado)
        {
            ayudaDescartar.SetActive(false);
            diarioAgarrado = null;
        }
    }

    void Update()
    {
        if (puedeAgarrar)
        {
            if (Physics.Raycast(transform.position, transform.forward, out raycastHit, 2f, layersAfectadas.value))
            {
                ayudaAgarrar.SetActive(true);
                if (Input.GetButton("Fire1"))
                {
                    diarioAgarrado = raycastHit.collider.GetComponent<Diario>();
                    diarioAgarrado.transform.SetParent(this.transform);
                    diarioAgarrado.transform.localPosition = posicionDeAgarreDiario.localPosition;
                    diarioAgarrado.transform.localRotation = posicionDeAgarreDiario.localRotation;
                    ayudaDescartar.SetActive(true);
                    ayudaAgarrar.SetActive(false);

                    diarioAgarrado.alActivar?.Invoke();
                    puedeAgarrar = false;
                }
            }
            else
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
