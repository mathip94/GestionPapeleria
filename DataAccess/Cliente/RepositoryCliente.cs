using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryCliente : Repository<Cliente>, IRepositoryCliente
    {
        public RepositoryCliente(DbContext dbContext)
        {
            Contexto = dbContext;
        }  

        public IEnumerable<Cliente> GetClienteByRazonSocialParcial(string textoBuscado)
        {
            textoBuscado = textoBuscado.ToLower();
            IEnumerable<Cliente> clientes = Contexto.Set<Cliente>()
                          .Include(d => d.Direccion)
                          .Where(cliente => cliente.RazonSocial.ToLower().Contains(textoBuscado))
                          .Distinct();
                          
            return clientes;
        }

        public IEnumerable<Cliente> GetClienteConPedidoMayorA(double monto)
        {
            IEnumerable<Pedido> pedidos = Contexto.Set<Pedido>()
                            .Where(pedido => pedido.Total > monto)
                            .Include(pedido => pedido.Cliente)
                            .ThenInclude(cliente => cliente.Direccion);

            IEnumerable<Cliente> clientes = pedidos.Select(pedido => pedido.Cliente).Distinct();

            return clientes;
        }

        public IEnumerable<Cliente> GetAll()
        {
            IEnumerable<Cliente> publicaciones = Contexto.Set<Cliente>();
                                        
            return publicaciones;
        }
    }
}
