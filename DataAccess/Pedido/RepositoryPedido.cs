using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryPedido : Repository<Pedido>, IRepositoryPedido
    {
       

        public RepositoryPedido(DbContext contexto)
        {
            Contexto = contexto;
        }

        public IEnumerable<Pedido> GetAll()
        {
            IEnumerable<Pedido> publicaciones = Contexto.Set<Pedido>()
                                        .Include(r => r.Cliente);                      
            return publicaciones;
        }

        public Pedido GetById(int id)
        {
            Pedido pedido = Contexto.Set<Pedido>().FirstOrDefault(p => p.Id == id);
            return pedido;
        }

        public IEnumerable<Pedido> GetManyAnuladosByDate(DateTime fecha)
        {
            IEnumerable<Pedido> pedidos = Contexto.Set<Pedido>()
                .Where(p => p.FechaPedido.Date == fecha.Date)
                .Where(p=> p.EstaAnulado == true)
                .Include(r => r.Cliente)
                .OrderByDescending(p => p.FechaPedido);
            return pedidos;
        }

        public IEnumerable<Pedido> GetManyByDate(DateTime fechaEmisionPedido) //Hay que probarlo
        {
            IEnumerable<Pedido> pedidos = Contexto.Set<Pedido>().Where(p => p.FechaPedido.Date == fechaEmisionPedido.Date && p.FechaEntrega > DateTime.Today).Include(r => r.Cliente);
            return pedidos;
        }

        public IEnumerable<Pedido> GetManyByDateNoAnulados(DateTime fecha)
        {
            IEnumerable<Pedido> pedidos = Contexto.Set<Pedido>().Where(p => p.FechaPedido.Date == fecha.Date && p.FechaEntrega > DateTime.Today).Where(p => p.EstaAnulado == false).Include(r => r.Cliente);
            return pedidos;
        }

        public void Update(Pedido item)
        {
            Contexto.Entry(item).State = EntityState.Modified;
            Contexto.SaveChanges();
        }
    }
}
