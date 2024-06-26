using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositoryPedidoComun : IRepository<PedidoComun> 
    {
        PedidoComun GetById(int id);
        IEnumerable<PedidoComun> GetManyByDate(DateTime fecha);
    }
}
