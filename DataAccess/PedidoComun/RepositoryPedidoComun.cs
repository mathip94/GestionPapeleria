using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryPedidoComun : Repository<PedidoComun>, IRepositoryPedidoComun
    {

        public RepositoryPedidoComun(DbContext contexto)
        {
            Contexto = contexto; //Dejarlo igual que Pedido
        }

        public PedidoComun GetById(int id)
        {
            PedidoComun pedido = Contexto.Set<PedidoComun>().FirstOrDefault(e => e.Id.CompareTo(id) == 0);
            return pedido;
        }

        public IEnumerable<PedidoComun> GetManyByDate(DateTime fecha)
        {
            IEnumerable<PedidoComun> pedidos = Contexto.Set<PedidoComun>().Where(p => p.FechaPedido.Date == fecha.Date).Include(r=>r.Cliente);
            return pedidos;
        }

    }
}
