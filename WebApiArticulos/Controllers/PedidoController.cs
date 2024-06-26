using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : Controller
    {
        private IServicioPedido _servicioPedido;

        public PedidosController(IServicioPedido servicioPedido)
        {
            _servicioPedido = servicioPedido;
        }

        [HttpGet]
        public IActionResult Get(DateTime fecha) 
        {
            IEnumerable<PedidoDto> pedidos = _servicioPedido.GetManyAnuladosByDate(fecha); //Recibe una fecha y lista todos los pedidos en esa fecha
            var pedidosResumen = pedidos.Select(p => new PedidoApiDto
            {
                FechaEntrega = p.FechaEntrega,
                ClienteDto = p.ClienteDto.RazonSocial,
                Total = p.Total
            });
            return Ok(pedidosResumen);
        }
    }
}
