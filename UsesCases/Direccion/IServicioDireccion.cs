using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UsesCases
{
    public interface IServicioDireccion : IServicioCRUD<DireccionDto>
    {
        IEnumerable<DireccionDto> GetByCalle(string calle);
    }
}
