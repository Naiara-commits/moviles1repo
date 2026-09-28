using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Usuario : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputNombre;  
    [SerializeField] private TMP_InputField inputEdad;    
    [SerializeField] private Button botonValidar;        

    private const string EscenaLista = "SampleScene";

    private TextMeshProUGUI textoError;
    private void Awake()
    {

        //validar nombres y edades
        inputNombre.characterLimit = ValidarUsuario.NombreMax;
        inputEdad.contentType = TMP_InputField.ContentType.IntegerNumber;

        inputEdad.characterLimit = 3;       //Maximo de numeros por edad


    }

}
