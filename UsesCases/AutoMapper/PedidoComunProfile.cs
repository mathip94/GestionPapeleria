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
    public class PedidoComunProfile : Profile
    {
        public PedidoComunProfile()
        {
            CreateMap<PedidoComunDto, PedidoComun>().ForMember(dest => dest.LineaPedidos, act => act.MapFrom(src => src.LineaPedidosDto));
            CreateMap<PedidoComun, PedidoComunDto>().ForMember(dest => dest.ClienteDto, act => act.MapFrom(src => src.Cliente));
                                                    
        }
        
    }
}
