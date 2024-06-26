using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositoryArticulo : IRepository<Articulo>
    {
        IEnumerable<Articulo> GetAll();
        Articulo GetByName(string nombre);
        Articulo GetByCodigo(string codigo);
    }
}
