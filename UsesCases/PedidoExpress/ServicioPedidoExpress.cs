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
    public class ServicioPedidoExpress : ServicioCRUD<PedidoExpress, PedidoExpressDto>, IServicioPedidoExpress
    {
        private IRepositoryPedidoExpress _repository;
        private IServicioParametro _servicioParametros;
        private readonly static string IVA_VALUE = "IVA";

        public ServicioPedidoExpress(IMapper mapper, IRepositoryPedidoExpress repository, IServicioParametro servicioParametros) : base(mapper, repository)
        {
            _repository = repository;
            _servicioParametros = servicioParametros;
        }
        public void AnularPedido(int id, PedidoExpressDto pedidoComunDto)
        {
            ThrowExceptionIfItIsNull(pedidoComunDto);
            pedidoComunDto.Validar();

            PedidoExpress model = _repository.Get(id);
            ThrowExceptionIfNotExistElement(model);
            PedidoExpress modelToCopy = _mapper.Map<PedidoExpress>(pedidoComunDto);
            model.Copy(modelToCopy);
            model.EstaAnulado = true;
            _repository.Update(model);
        }

        public IEnumerable<PedidoExpressDto> GetManyByDate(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public PedidoExpressDto Add(PedidoExpressDto pedidoExpressDto)
        {
            ThrowExceptionIfItIsNull(pedidoExpressDto);
            pedidoExpressDto.Validar();
            double prcIva = Double.Parse(_servicioParametros.Get(IVA_VALUE).Valor);
            pedidoExpressDto.CalcularTotal(prcIva); //Calcula subtotal impuestos recargo y total y los añade al modelo antes de agregarlo
            PedidoExpress model = _mapper.Map<PedidoExpress>(pedidoExpressDto);
            PedidoExpress newModel = _repository.Add(model);
            PedidoExpressDto newDto = _mapper.Map<PedidoExpressDto>(newModel);
            return newDto;
        }

        public double CalcularTotal(PedidoExpressDto pedidoExpressDto)
        {
            double prcIva = Double.Parse(_servicioParametros.Get(IVA_VALUE).Valor);
            pedidoExpressDto.CalcularTotal(prcIva);
            double total = pedidoExpressDto.Total;
            return total;
        }
    }
}
