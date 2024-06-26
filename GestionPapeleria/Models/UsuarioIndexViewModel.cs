using Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace GestionPapeleriaWebApp.Models;

public class UsuarioIndexViewModel
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
}

public class UsuarioCreateViewModel
{
    
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UsuarioUpdateViewModel
{
    
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UsuarioDeleteViewModel
{
    public string Email { get; set; }
}







