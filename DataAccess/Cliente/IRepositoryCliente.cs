using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        IEnumerable<Cliente> GetClienteByRazonSocialParcial(string textoBuscado);
        IEnumerable<Cliente> GetClienteConPedidoMayorA(double monto);
        IEnumerable<Cliente> GetAll();
    }
}
