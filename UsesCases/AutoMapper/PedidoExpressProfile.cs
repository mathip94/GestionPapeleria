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
    public class PedidoExpressProfile : Profile
    {
        public PedidoExpressProfile()
        {
            CreateMap<PedidoExpressDto, PedidoExpress>();
            CreateMap<PedidoExpress, PedidoExpressDto>().ForMember(dest => dest.ClienteDto, act => act.MapFrom(src => src.Cliente)); 
        }
    }
}
