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
    public class LineaPedidoProfile : Profile
    {
        public LineaPedidoProfile() 
        {
            CreateMap<LineaPedidoDto, LineaPedido>();
            CreateMap<LineaPedido, LineaPedidoDto>().ForMember(dest => dest.PedidoDto, act => act.MapFrom(src => src.Pedido))
                                                    .ForMember(dest => dest.ArticuloDto, act => act.MapFrom(src => src.Articulo)); 
        }
        
    }
}
