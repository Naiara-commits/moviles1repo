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
        var raiz = (RectTransform)FindFirstObjectByType<Canvas>().transform;
        //validar nombres y edades
        inputNombre.characterLimit = ValidadorUsuario.NombreMax;
        inputEdad.contentType = TMP_InputField.ContentType.IntegerNumber;

        inputEdad.characterLimit = 3;       //Maximo de numeros por edad

        //Msj error si no es correcto



    }

}
