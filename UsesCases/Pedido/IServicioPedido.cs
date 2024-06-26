using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public interface IServicioPedido
    {
        IEnumerable<PedidoDto> GetAll();
        PedidoDto GetById(int id);
        IEnumerable<PedidoDto> GetManyByDate(DateTime fecha);
        IEnumerable<PedidoDto> GetManyByDateNoAnulados(DateTime fecha);
        IEnumerable<PedidoDto> GetManyAnuladosByDate(DateTime fecha);
        void UpdateAnular(PedidoDto item);

    }
}
