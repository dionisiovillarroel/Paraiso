using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitilarTexto : MonoBehaviour
{
    [SerializeField]
    private Text textoControlado;

    [SerializeField]
    private float duracionCiclo = 1f;

    private void OnEnable()
    {
        StartCoroutine(Titilar());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Titilar()
    {
        YieldInstruction espera = new WaitForSeconds(duracionCiclo);

        while (true)
        {
            yield return espera;
            textoControlado.enabled = !textoControlado.enabled;
        }
    }
}
