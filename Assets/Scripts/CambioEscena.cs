using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    string texto = "HolaMundo"; //Input de nombre
    bool esPalabra = texto.All(char.IsLetter);
    int numero = "5";   //Input de numero
    bool esNumero = .All(int.)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambioAñadir()
    {
        SceneManager.LoadScene("UsuarioNuevo");
    }


    public void AñadirUsuario()
    {
        if (esNumero == true && esPalabra == true)
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }
}
