using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoLocalizado : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField]
    private AudioSource sonido;

    [Header("Parámetros")]
    [SerializeField]
    private float rotacionMax = 30f;
    [SerializeField]
    private float volumenMin = 0f;
    [SerializeField]
    private float volumenMax = 1f;

    private Transform transformDeCamara;
    private float angulo;

    [SerializeField]
    private float totalDeEscucha = 0f;

    private void Awake()
    {
        transformDeCamara = Camera.main.transform;
    }

    void Update()
    {
        angulo = transform.rotation.eulerAngles.y - transformDeCamara.rotation.eulerAngles.y;
        sonido.panStereo = Mathf.Clamp(angulo / rotacionMax, -1f, 1f);
        sonido.volume = Mathf.Lerp(volumenMax, volumenMin, Mathf.Abs(angulo) / rotacionMax);
        totalDeEscucha += sonido.volume * Time.deltaTime;
    }
}
