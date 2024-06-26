using Domain.Dtos;
using Domain.Models;

namespace GestionPapeleriaWebApp.Models
{
    public class AnularPedidoViewModel
    {
        public DateTime FechaPedido { get; set; }
        public IEnumerable<PedidoDto> Pedidos { get; set; }
        public int Id { get; set; }

        public AnularPedidoViewModel()
        {
            FechaPedido = DateTime.Today;
        }
    }
}
