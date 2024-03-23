using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionAlFinalDeAudio : MonoBehaviour
{
    [SerializeField]
    private FadeYTransicion controlDeTransicion;
    [SerializeField]
    private AudioSource audioSupervisado;

    private void Start()
    {
        StartCoroutine(EsperarAudio());
    }

    private IEnumerator EsperarAudio()
    {
        print("Inicia espera por " + (audioSupervisado.clip.length + 2f));
        yield return new WaitForSeconds(audioSupervisado.clip.length + 2f);
        print("Fin espera");
        controlDeTransicion.ActivarTransicion();
    }
}
