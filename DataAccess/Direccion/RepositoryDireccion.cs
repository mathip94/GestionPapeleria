using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryDireccion : Repository<Direccion>, IRepositoryDireccion
    {
        public RepositoryDireccion(DbContext dbContext)
        {
            Contexto = dbContext;
        }


        public IEnumerable<Direccion> GetByCalle(string calle)
        {
            IEnumerable<Direccion> Calles = Contexto.Set<Direccion>()
                                        .Where(Direccion => Direccion.Calle.Contains(calle));
            return Calles;
        }
    }
}
