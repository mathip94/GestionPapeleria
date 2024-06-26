using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositoryPedido : IRepository<Pedido>
    {
        IEnumerable<Pedido> GetAll();
        Pedido GetById(int id);
        IEnumerable<Pedido> GetManyByDate(DateTime fecha);
        IEnumerable<Pedido> GetManyByDateNoAnulados(DateTime fecha);
        IEnumerable<Pedido> GetManyAnuladosByDate(DateTime fecha);
        void Update(Pedido item);
    }
}
