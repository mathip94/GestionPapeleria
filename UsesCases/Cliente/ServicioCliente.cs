using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UsesCases
{
    public class ServicioCliente : ServicioCRUD<Cliente, ClienteDto>, IServicioCliente
    {
        private IRepositoryCliente _repository;

        public ServicioCliente(IMapper mapper, IRepositoryCliente repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public IEnumerable<ClienteDto> GetClienteByRazonSocialParcial(string textoBuscado)
        {
            IEnumerable<Cliente> cliente = _repository.GetClienteByRazonSocialParcial(textoBuscado);
            IEnumerable<ClienteDto> clienteDto = _mapper.Map<IEnumerable<ClienteDto>>(cliente);
            return clienteDto;
        }

        public IEnumerable<ClienteDto> GetClienteConPedidoMayorA(double monto) 
        {
            IEnumerable<Cliente> cliente = _repository.GetClienteConPedidoMayorA(monto);
            IEnumerable<ClienteDto> clienteDto = _mapper.Map<IEnumerable<ClienteDto>>(cliente);
            return clienteDto;
        }

        public IEnumerable<ClienteDto> GetAll()
        {
            IEnumerable<Cliente> pedido = _repository.GetAll();
            IEnumerable<ClienteDto> pedidoDtos = _mapper.Map<IEnumerable<ClienteDto>>(pedido); ;
            return pedidoDtos;
        }
    }
}
