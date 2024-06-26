using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class LineaPedidoDto
    {
        public int Id { get; set; }
        public ArticuloDto ArticuloDto { get; set; }
        public int UnidadesPedidas { get; set; }
        public double PrecioUnitario { get; set; }
        public PedidoDto PedidoDto { get; set; }
        public int PedidoId { get; set; }
        public int ArticuloId { get; set; }

        public double CalcularSubTotal()
        {
            return PrecioUnitario * UnidadesPedidas;
        }
    }
}
