using Domain.Dtos;

namespace GestionPapeleriaWebApp.Models
{
    public class ClienteIndexViewModel
    {
        public string TextoBusqueda { get; set; }
        public double Monto { get; set; }
        public IEnumerable<ClienteDto> Resultados { get; set; }
    }
}
