using UnityEngine;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.WSA;

public class Pntalla1 : MonoBehaviour
{
    [SerializeField] private Button botonAnadir;       
    [SerializeField] private Button botonMayorEdad;    
    [SerializeField] private ScrollRect scrollLista; 

    [SerializeField] private float segundosEliminar = 3f;

    private const string EscenaNuevoUsuario = "UsuarioNuevo";

    private RepositorioUsuarios repositorio;
    private RectTransform contenido;
    private TMP_InputField inputBuscar;
    private TextMeshProUGUI textoResultado, _textoCabecera;
    private GameObject overlay;
    private TextMeshProUGUI _textoEliminar, _textoCuentaAtras;
    private Slider barra;
    private ToastUI toast;
    private Coroutine rutinaEliminar;

    private void Awake()
    {
        repositorio = EstadoApp.Repositorio;
        var raiz = (RectTransform)FindFirstObjectByType<Canvas>().transform;

        var area = AreaSegura.Crear(raiz);
        ConstruirInterfaz(area);
        ConfigurarContenido();
        ConstruirOverlay(raiz);
        toast = ToastUI.Crear(raiz);

        ActualizarLista();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
