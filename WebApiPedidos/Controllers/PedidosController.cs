using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace WebApiPedidos.Controllers
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
        public IActionResult Get()
        {
            IEnumerable<PedidoDto> pedidos = _servicioPedido.GetAll();
            return Ok(pedidos);
        }
    }
}
