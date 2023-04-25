using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class ReadingText : MonoBehaviour
{
    //para el diálogo
    public TextAsset textFile;     // drop your file here in inspector
    string[] linesArray;
    
    int linepos = 0;

    //elementos en la UI
    [SerializeField] TextMeshProUGUI txt_dialogo;

    public Button opcion1;
    public Button opcion2;
    
    // Start is called before the first frame update
    void Start()
    {
        //borramos cualquier texto que pueda haber en pantalla
        txt_dialogo.text = "";

        //desactivamos los botones
        opcion1.gameObject.SetActive(false); 
        opcion2.gameObject.SetActive(false);

        ReadFromTheFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadFromTheFile()
    {
        //guardamos las oraciones del archivo de texto en un array
        linesArray = textFile.text.Split("\n");
    }

    //este método se llama desde el botón cuando es presionado
    public void DisplayText()
    {
        Debug.Log(linepos);
        Debug.Log(linesArray.Length);

        if(linepos >= linesArray.Length)
        {
            //si ya acabó el diálogo, hay que llamar al menú de opciones
            opcion1.gameObject.SetActive(true);
            opcion2.gameObject.SetActive(true);

            return;
        }
        else
        {
            txt_dialogo.text = "";

            txt_dialogo.text += linesArray[linepos] + "\n";
            linepos++;
        }
    }
}
