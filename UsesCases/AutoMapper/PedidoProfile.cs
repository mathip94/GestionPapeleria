using AutoMapper;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases.AutoMapper
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<PedidoDto, Pedido>()
                .Include<PedidoDto, PedidoComun>()
                .Include<PedidoDto, PedidoExpress>();

            CreateMap<PedidoDto, PedidoComun>();
            CreateMap<PedidoDto, PedidoExpress>();

            CreateMap<Pedido, PedidoDto>()
                .Include<PedidoComun, PedidoComunDto>()
                .Include<PedidoExpress, PedidoExpressDto>()
                .ForMember(dest => dest.ClienteDto, act => act.MapFrom(src => src.Cliente));

            
        }
    }
}
