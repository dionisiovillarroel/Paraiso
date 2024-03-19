using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaCubo : MonoBehaviour
{
    [SerializeField]
    private GameObject ayudaCarga;

    [SerializeField]
    private LayerMask layersAfectadas;
    private RaycastHit raycastHit;
    

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, 2f, layersAfectadas.value))
        {
            ayudaCarga.SetActive(true);
            print("Vio");
            if (Input.GetButton("Fire1"))
            {
                raycastHit.collider.GetComponent<Cubo>().Cargar();
            }
        }
        else
        {
            ayudaCarga.SetActive(false);
        }
    }
}
