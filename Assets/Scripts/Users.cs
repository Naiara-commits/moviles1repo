using UnityEngine;
using System.Collections.Generic;

public static class EstadoApp
{
    public static readonly Users Repositorio = new Users();
    public static string mensajePendiente;
}
public class Users : MonoBehaviour
{
    private const int IdMin = 1000;
    private const int IdMax = 9999;

    private readonly List<Usuario> usuarios = new List<Usuario>();
    private readonly System.Random random = new System.Random();

    public IReadOnlyList<Usuario> Todos => usuarios;

    public Usuario Anadir(string nombre, int edad)
    {
        var usuario = new Usuario(GenerarIdUnico(), nombre, edad);
        usuarios.Add(usuario);
        return usuario;
    }
    private int GenerarIdUnico()
    {
        if (usuarios.Count > IdMax - IdMin)
            throw new System.InvalidOperationException("No quedan IDs disponibles.");

        int id;
        do
        {
            id = random.Next(IdMin, IdMax + 1);
        } while (BuscarPorId(id) != null);
        return id;
    }
    public Usuario BuscarPorId(int id)
    {
        foreach (Usuario usuario in usuarios)
        {
            if (usuario.Id == id) return usuario;
        }
        return null; // no existe
    }
    public bool Eliminar(int id)
    {
        Usuario usuario = BuscarPorId(id);
        if (usuario == null) return false;
        return usuarios.Remove(usuario);
    }
    public List<Usuario> ObtenerMayoresDeEdad()
    {
        var mayores = new List<Usuario>();

        foreach (Usuario usuario in usuarios)
        {
            if (mayores.Count == 0 || usuario.Edad > mayores[0].Edad)
            {
                // Nuevo máximo: descartamos los anteriores y empezamos de nuevo
                mayores.Clear();
                mayores.Add(usuario);
            }
            else if (usuario.Edad == mayores[0].Edad)
            {
                mayores.Add(usuario); // Empate con el máximo actual
            }
        }
        return mayores;
    }
}
public static class ValidadorUsuario
{
    public const int NombreMin = 1;
    public const int NombreMax = 30;
    public const int EdadMin = 1;
    public const int EdadMax = 200;

    public static bool TryValidar(string nombreTexto, string edadTexto,
                                  out string nombre, out int edad, out string error)
    {
        nombre = (nombreTexto ?? "").Trim();
        edad = 0;
        error = null;

        if (nombre.Length == 0) { error = "El nombre es obligatorio."; return false; }
        if (nombre.Length < NombreMin || nombre.Length > NombreMax)
        {
            error = $"El nombre debe tener entre {NombreMin} y {NombreMax} caracteres.";
            return false;
        }
        foreach (char c in nombre)
        {
            if (!(char.IsLetterOrDigit(c) || c == ' ' || c == '_'))
            {
                error = "El nombre solo puede contener letras, números, espacios y '_'.";
                return false;
            }
        }

        if (string.IsNullOrWhiteSpace(edadTexto)) { error = "La edad es obligatoria."; return false; }
        if (!int.TryParse(edadTexto.Trim(), out edad)) { error = "La edad debe ser un número entero."; return false; }
        if (edad < EdadMin || edad > EdadMax)
        {
            error = $"La edad debe estar entre {EdadMin} y {EdadMax}.";
            return false;
        }
        return true;
    }
}
