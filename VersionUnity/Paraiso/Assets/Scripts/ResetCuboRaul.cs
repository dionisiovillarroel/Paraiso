using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCuboRaul : MonoBehaviour
{
    
    [SerializeField]
    private AudioSource sonidoCargaBuena;
    [SerializeField]
    private AudioSource sonidoCargaMala;

    public void ReiniciarCarga()
    {
        float carga = Random.Range(0f, 1f);
        if (carga > 0.5f)
        {
            sonidoCargaBuena.Play();
        }
        else
        {
            sonidoCargaMala.Play();
        }
    }
}
