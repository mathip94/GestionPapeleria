using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace WebApiArticulos.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ArticulosController : Controller
    {
        private IServicioArticulo _servicioArticulo;

        public ArticulosController(IServicioArticulo servicioArticulo)
        {
            _servicioArticulo = servicioArticulo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ArticuloDto> articulos = _servicioArticulo.GetAll();
            return Ok(articulos);
        }
    }
}
