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
    public class ServicioPedidoComun : ServicioCRUD<PedidoComun, PedidoComunDto>, IServicioPedidoComun 
    {
        private IRepositoryPedidoComun _repository;
        private IServicioParametro _servicioParametros;
        private readonly static string IVA_VALUE= "IVA";
        public ServicioPedidoComun(IMapper mapper, IRepositoryPedidoComun repository, IServicioParametro servicioParametros) : base(mapper, repository)
        {
            _repository = repository;
            _servicioParametros = servicioParametros;
        }


        public IEnumerable<PedidoComunDto> GetManyByDate(DateTime fecha) //Puede no ser necesario
        {
            throw new NotImplementedException();
        }

        public void AnularPedido(int id, PedidoComunDto pedidoComunDto)
        {
            ThrowExceptionIfItIsNull(pedidoComunDto);
            pedidoComunDto.Validar();

            PedidoComun model = _repository.Get(id);
            ThrowExceptionIfNotExistElement(model);
            PedidoComun modelToCopy = _mapper.Map<PedidoComun>(pedidoComunDto);
            model.Copy(modelToCopy);
            model.EstaAnulado = true;
            _repository.Update(model);
        }

        public PedidoComunDto Add(PedidoComunDto pedidoComunDto)
        {
            ThrowExceptionIfItIsNull(pedidoComunDto);
            pedidoComunDto.Validar();
            double prcIva = Double.Parse(_servicioParametros.Get(IVA_VALUE).Valor);
            pedidoComunDto.CalcularTotal(prcIva);//Calcula subtotal impuestos recargo y total y los añade al modelo antes de agregarlo
            PedidoComun model = _mapper.Map<PedidoComun>(pedidoComunDto);
            PedidoComun newModel = _repository.Add(model);
            PedidoComunDto newDto = _mapper.Map<PedidoComunDto>(newModel);
            return newDto;
        }

        public double CalcularTotal(PedidoComunDto pedidoComunDto)
        {
            double prcIva = Double.Parse(_servicioParametros.Get(IVA_VALUE).Valor);
            pedidoComunDto.CalcularTotal(prcIva);
            double total = pedidoComunDto.Total;
            return total;
        }
    }
}
