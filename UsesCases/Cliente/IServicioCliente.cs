using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases
{
    public interface IServicioCliente : IServicioCRUD<ClienteDto>
    {
        IEnumerable<ClienteDto> GetClienteByRazonSocialParcial(string textoBuscado);
        IEnumerable<ClienteDto> GetClienteConPedidoMayorA(double monto);
        IEnumerable<ClienteDto> GetAll();
    }
}
