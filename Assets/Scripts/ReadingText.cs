using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ReadingText : MonoBehaviour
{
    //para el di�logo
    public TextAsset textFile;     // drop your file here in inspector
    string[] linesArray;
    
    public int linepos = 0;
    

    //elementos en la UI
    [SerializeField] TextMeshProUGUI txt_dialogo;

    public Button opcion1;
    public Button opcion2;
    public Button opcion3;

    public Canvas canvas;

    public Animator Alex;
    public Animator Personaje_Izquierda;
    public Animator Personaje_Derecha;

    

    // Start is called before the first frame update
    void Start()
    {

        //borramos cualquier texto que pueda haber en pantalla
        txt_dialogo.text = "";

        //desactivamos los botones

        string tag = canvas.tag;

        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
        opcion1.gameObject.SetActive(false);
        opcion2.gameObject.SetActive(false);
        opcion3.gameObject.SetActive(false);
        
        
        ReadFromTheFile();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "Escena 1")
        {
            Alex.SetInteger("LINEAPOS01", linepos);
        }
        if(scene.name == "Escena 3")
        {
            Alex.SetInteger("LINEAPOS03", linepos);
            Personaje_Izquierda.SetInteger("LINEAPOS03", linepos);
            Personaje_Derecha.SetInteger("LINEAPOS03", linepos);
        }
        if (scene.name == "Escena 3.1")
        {
            Alex.SetInteger("LINEAPOS03.1", linepos);
            Personaje_Izquierda.SetInteger("LINEAPOS03.1", linepos);
            Personaje_Derecha.SetInteger("LINEAPOS03.1", linepos);
        }
    }

    void ReadFromTheFile()
    {
        //guardamos las oraciones del archivo de texto en un array
        linesArray = textFile.text.Split("\n");
    }

    

    //este m�todo se llama desde el bot�n cuando es presionado
    public void DisplayText()
    {
        //Debug.Log(linepos);
        //Debug.Log(linesArray.Length);
        Scene scene = SceneManager.GetActiveScene();
        if (linepos >= linesArray.Length)
        {
            //si ya acab� el di�logo, hay que llamar al men� de opciones
            if (canvas.tag == "OneOption") //Este es para escenas que no tienen opciones y saltan a otra
            {
                opcion3.gameObject.SetActive(true); 
            }
            if (canvas.tag == "TwoOption") //Este es para escenas que necesiten 2 opciones
            {
                opcion1.gameObject.SetActive(true);
                opcion2.gameObject.SetActive(true);
            }
            
            if (scene.name == "Escena 1") //Este es porque s�lo en la primera escena hay 3 opciones
            {
                opcion1.gameObject.SetActive(true);
                opcion2.gameObject.SetActive(true);
                opcion3.gameObject.SetActive(true);
            }


            /*if ((scene.name != "Escena 2.1")) //Con este if evitamos que aparezcan los botones en los finales uwu
            {
                opcion1.gameObject.SetActive(true);
                opcion2.gameObject.SetActive(true);
            }

            if (scene.name == "Escena 1") //Este es porque s�lo en la primera escena hay 3 opciones
            {
                opcion3.gameObject.SetActive(true);
            }   
            else
            {
                //No hace nada gg
            }*/

            return;
        }
        else
        {
            txt_dialogo.text = "";

            txt_dialogo.text += linesArray[linepos] + "\n";
            linepos++;
            
            return;
        }
    }
    public int MandarNumeroLinea()
    {
        return linepos;
    }
}
