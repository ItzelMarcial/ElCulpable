using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class ReadingText : MonoBehaviour
{
    //para el di�logo
    public TextAsset textFile;     // drop your file here in inspector
    string[] linesArray;
    string myFilePath, filename;
    int linepos = 0;

    //elementos en la UI
    [SerializeField] TextMeshProUGUI txt_dialogo;
    
    // Start is called before the first frame update
    void Start()
    {
        //string text = textFile.text;  //this is the content as string
        filename = "Esc01.txt";
        myFilePath = Application.dataPath + "/" + filename;
        txt_dialogo.text = "";
        ReadFromTheFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadFromTheFile()
    {
        linesArray = File.ReadAllLines(myFilePath);
    }

    //este m�todo se llama desde el bot�n cuando es presionado
    public void DisplayText()
    {
        if(linepos >= linesArray.Length)
        {
            //si ya acab� el di�logo, hay que llamar al men� de opciones
            return;
        }
        txt_dialogo.text = "";

        txt_dialogo.text += linesArray[linepos] + "\n";
        linepos++;
    }
}
