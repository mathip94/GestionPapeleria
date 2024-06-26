using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public class ServicioPedido : ServicioCRUD<Pedido, PedidoDto>, IServicioPedido
    {
        private IRepositoryPedido _repository;
        private IMapper _mapper;

        public ServicioPedido(IMapper mapper, IRepositoryPedido repository) : base(mapper, repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PedidoDto> GetAll()
        {
            IEnumerable<Pedido> pedido = _repository.GetAll();
            IEnumerable<PedidoDto> pedidoDtos = _mapper.Map<IEnumerable<PedidoDto>>(pedido); ;
            return pedidoDtos;
        }

        public PedidoDto GetById(int id)
        {
            Pedido pedido = _repository.GetById(id);
            PedidoDto pedidoDto = _mapper.Map<PedidoDto>(pedido);
            return pedidoDto;
        }

        public IEnumerable<PedidoDto> GetManyByDate(DateTime fecha)
        {
            IEnumerable<Pedido> pedido = _repository.GetManyByDate(fecha);
            IEnumerable<PedidoDto> pedidoDtos = _mapper.Map<IEnumerable<PedidoDto>>(pedido); ;
            return pedidoDtos;
        }

        public IEnumerable<PedidoDto> GetManyByDateNoAnulados(DateTime fecha)
        {
            IEnumerable<Pedido> pedido = _repository.GetManyByDateNoAnulados(fecha);
            IEnumerable<PedidoDto> pedidoDto = _mapper.Map<IEnumerable<PedidoDto>>(pedido);
            return pedidoDto;
        }

        public IEnumerable<PedidoDto> GetManyAnuladosByDate(DateTime fecha)
        {
            IEnumerable<Pedido> pedido = _repository.GetManyAnuladosByDate(fecha);
            IEnumerable<PedidoDto> pedidoDtos = _mapper.Map<IEnumerable<PedidoDto>>(pedido); ;
            return pedidoDtos;
        }

        public void UpdateAnular(PedidoDto pedidoDto)
        {
            ThrowExceptionIfItIsNull(pedidoDto);
            pedidoDto.Validar();

            pedidoDto.AnularPedido();

            Pedido model = _repository.GetById(pedidoDto.Id);
            ThrowExceptionIfNotExistElement(model);

            Pedido modelToCopy;
            if (model is PedidoComun)
            {
                modelToCopy = _mapper.Map<PedidoComun>(pedidoDto);
            }
            else if (model is PedidoExpress)
            {
                modelToCopy = _mapper.Map<PedidoExpress>(pedidoDto);
            }
            else
            {
                throw new InvalidOperationException("Tipo de pedido desconocido.");
            }

            model.Copy(modelToCopy);
            _repository.Update(model);
        }

    }
}
