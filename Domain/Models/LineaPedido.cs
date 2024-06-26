using Domain.Interfaces;

namespace Domain.Models
{
    public class LineaPedido : IValidable
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public int UnidadesPedidas { get; set; }
        public double PrecioUnitario { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public int ArticuloId { get; set; }

        

        public void Validar()
        {
            if (Articulo.Stock <= 0 ) { throw new Exception($"No hay mas stock de {Articulo.Nombre}"); }
        }

        public double CalcularSubTotal()
        {
            return PrecioUnitario * UnidadesPedidas;
        }

    }
}
