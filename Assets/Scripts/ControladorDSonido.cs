using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDSonido : MonoBehaviour
{
    public AudioSource reprodSonidos;


    public void PlayThisFx()
    {
        reprodSonidos.Play();
    }
}
