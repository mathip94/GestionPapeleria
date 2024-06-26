using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositoryDireccion : IRepository<Direccion>
    {
        IEnumerable<Direccion> GetByCalle(string calle);
    }
}
