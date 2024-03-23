using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilitarCapucha : MonoBehaviour
{
    [SerializeField]
    private Collider colliderQueActiva;
    [SerializeField]
    private AudioSource audioSupervisado;

    private void Start()
    {
        StartCoroutine(EsperarAudio());
    }

    private IEnumerator EsperarAudio()
    {
        yield return new WaitForSeconds(audioSupervisado.clip.length + 2f);
        colliderQueActiva.enabled = true;
    }
}
