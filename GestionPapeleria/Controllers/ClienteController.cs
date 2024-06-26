using Microsoft.AspNetCore.Mvc;
using UsesCases;
using GestionPapeleriaWebApp.Models;

namespace GestionPapeleriaWebApp.Controllers
{
    public class ClienteController : Controller
    {
        private IServicioCliente _servicioCliente;

        public ClienteController(IServicioCliente servicioCliente)
        {
            _servicioCliente = servicioCliente;
        }

        public IActionResult Buscar()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            var viewModel = new ClienteIndexViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult BuscarPorTexto(ClienteIndexViewModel viewModel)
        {
            viewModel.Resultados = _servicioCliente.GetClienteByRazonSocialParcial(viewModel.TextoBusqueda);
            return View("Buscar", viewModel);
        }

        [HttpPost]
        public IActionResult BuscarPorMonto(ClienteIndexViewModel viewModel)
        {
            viewModel.Resultados = _servicioCliente.GetClienteConPedidoMayorA(viewModel.Monto);
            return View("Buscar", viewModel);
        }
    }
}
