using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    private Animator MiAnimador;
    private ReadingText lineasTexto;
    
    // Start is called before the first frame update
    void Start()
    {
        lineasTexto = GetComponent<ReadingText>();
        MiAnimador = GetComponent<Animator>();
        

    }
   
    // Update is called once per frame
    void Update()
    {
        
        
        
            //MiAnimador.SetTrigger("lineaCorrecta");
        
       
    }

    
}
