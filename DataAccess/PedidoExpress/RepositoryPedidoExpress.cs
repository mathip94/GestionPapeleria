using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryPedidoExpress : Repository<PedidoExpress>, IRepositoryPedidoExpress
    {
        public RepositoryPedidoExpress(DbContext contexto)
        {
            Contexto = contexto;
        } 

        public PedidoExpress GetById(int id)
        {
            PedidoExpress pedido = Contexto.Set<PedidoExpress>().FirstOrDefault(e => e.Id.CompareTo(id) == 0);
            return pedido;
        }

        public IEnumerable<PedidoExpress> GetManyByDate(DateTime fecha)
        {
            IEnumerable<PedidoExpress> pedidos = Contexto.Set<PedidoExpress>().Where(p => p.FechaPedido.Date == fecha.Date).Include(r => r.Cliente);
            return pedidos;
        }

    }
}
