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
    public class ServicioDireccion : ServicioCRUD<Direccion,DireccionDto>, IServicioDireccion
    {
        private IRepositoryDireccion _repository;

        public ServicioDireccion(IMapper mapper, IRepositoryDireccion repository) : base(mapper, repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<DireccionDto> GetByCalle(string calle)
        {
            IEnumerable<Direccion> Direcciones = _repository.GetByCalle(calle);
            IEnumerable<DireccionDto> DireccionesDto = _mapper.Map<IEnumerable<DireccionDto>>(Direcciones); 
            return DireccionesDto;
        }

       
    }
}
