using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases.AutoMapper
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile() 
        {
            CreateMap<Cliente, ClienteDto>().ForMember(dest => dest.DireccionDto, act => act.MapFrom(src => src.Direccion)); 
            CreateMap<ClienteDto, Cliente>();
        }
    }
}
