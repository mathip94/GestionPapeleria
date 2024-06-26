using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PedidoApiDto
    {
        public DateTime FechaEntrega { get; set; }
        public string ClienteDto { get; set; }
        public double Total { get; set; }
    }
}
