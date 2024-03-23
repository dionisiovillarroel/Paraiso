using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoraIntro : MonoBehaviour
{
    [SerializeField]
    private float demoraBoton = 1f;

    [SerializeField]
    private GameObject botonSeguir;

    private void Start()
    {
        StartCoroutine(ActivarBotonParaSeguir());
    }

    private IEnumerator ActivarBotonParaSeguir()
    {
        yield return new WaitForSeconds(demoraBoton);
        botonSeguir.SetActive(true);
    }
}
