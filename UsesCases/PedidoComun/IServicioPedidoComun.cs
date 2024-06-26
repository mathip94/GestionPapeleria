using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public interface IServicioPedidoComun : IServicioCRUD<PedidoComunDto>
    {
        IEnumerable<PedidoComunDto> GetManyByDate(DateTime fecha);
        void AnularPedido(int id, PedidoComunDto pedidoComunDto);
        PedidoComunDto Add(PedidoComunDto pedidoComunDto);

        double CalcularTotal(PedidoComunDto pedidoComunDto);

    }
}
