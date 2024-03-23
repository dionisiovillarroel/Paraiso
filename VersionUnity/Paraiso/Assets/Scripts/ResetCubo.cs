using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCubo : MonoBehaviour
{
    [SerializeField]
    private Cubo cubo;

    [SerializeField]
    private float minimoCargaCorrecta = 0.6f;
    [SerializeField]
    private AudioSource sonidoCargaPerfecta;
    [SerializeField]
    private AudioSource sonidoCargaBuena;
    [SerializeField]
    private AudioSource sonidoCargaMala;

    public void ReiniciarCarga()
    {
        float cargaCuboRecibido = cubo.carga;

        if (cargaCuboRecibido >= 1f)
        {
            sonidoCargaPerfecta.Play();
        }
        else if (cargaCuboRecibido >= minimoCargaCorrecta)
        {
            sonidoCargaBuena.Play();
        }
        else
        {
            sonidoCargaMala.Play();
        }
        cubo.ReiniciarCarga();
    }
}
