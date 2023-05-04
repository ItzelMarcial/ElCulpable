using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController Instancia;
    

    // Start is called before the first frame update
    void Start()
    {
        Instancia = this;
        
    }

    public void CambiarAEscena(int numeroEscena)
    {
        SceneManager.LoadScene(numeroEscena);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
