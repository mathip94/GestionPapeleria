using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionPapeleriaWebApp.Models
{
    public class PedidoViewModel
    {
        public int ClienteId { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public List<LineaPedidoViewModel> LineasPedido { get; set; }
        public double TotalPedido { get; set; }

        public PedidoViewModel()
        {
            FechaEntrega = DateTime.Today;  
        }
    }
}
