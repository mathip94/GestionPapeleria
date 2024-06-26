using System.ComponentModel.DataAnnotations;

namespace GestionPapeleriaWebApp.Models
{
    public class ArticuloViewModel
    {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string Codigo { get; set; }
            public double PrecioVenta { get; set; }
            public int Stock { get; set; }
    }
}
