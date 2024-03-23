using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeYTransicion : MonoBehaviour
{
    [SerializeField]
    private Image          imagenFade;
    [SerializeField]
    private float          duracionFade;
    [SerializeField]
    private string         escenaACargar;

    private float          tiempo = 0;
    private AsyncOperation carga;

    private void Start()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        carga = SceneManager.LoadSceneAsync(escenaACargar);
        carga.allowSceneActivation = false;
        imagenFade.enabled = true;
        imagenFade.CrossFadeAlpha(0f, duracionFade, false);
    }

    public void ActivarTransicion()
    {
        StartCoroutine(Transicion());
    }

    private IEnumerator Transicion()
    {
        imagenFade.CrossFadeAlpha(1f, duracionFade, false);
        yield return new WaitForSeconds(duracionFade+1f);
        carga.allowSceneActivation = true;
        Application.backgroundLoadingPriority = ThreadPriority.Normal;
    }
}
