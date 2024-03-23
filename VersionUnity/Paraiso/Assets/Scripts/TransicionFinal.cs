using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionFinal : MonoBehaviour
{
    [SerializeField]
    private FadeYTransicion sistemaDeControl;

    public void Iniciar()
    {
        sistemaDeControl.ActivarTransicion();
    }
}
