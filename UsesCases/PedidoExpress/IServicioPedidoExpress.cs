using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public interface IServicioPedidoExpress : IServicioCRUD<PedidoExpressDto>
    {
        IEnumerable<PedidoExpressDto> GetManyByDate(DateTime fecha);
        void AnularPedido(int id, PedidoExpressDto pedidoExpressDto);
        PedidoExpressDto Add(PedidoExpressDto pedidoExpressDto);
        double CalcularTotal(PedidoExpressDto pedidoExpressDto);
    }
}
