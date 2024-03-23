using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirManteniendoTecla : MonoBehaviour
{
    [SerializeField]
    private KeyCode teclaSalir = KeyCode.Escape;
    [Range(0.5f,4f)]
    [SerializeField]
    private float duracionParaSalir = 2f;

    private float tiempoApretada = 0f;

    private void Update()
    {
        if (Input.GetKey(teclaSalir))
        {
            tiempoApretada += Time.deltaTime;
            if (tiempoApretada > duracionParaSalir)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Menu");
            }
        }
        else if (Input.GetKeyUp(teclaSalir))
        {
            tiempoApretada = 0f;
        }
    }
}
