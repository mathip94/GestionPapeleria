using Microsoft.AspNetCore.Mvc;
using UsesCases;
using Domain.Dtos;
using GestionPapeleriaWebApp.Models;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionPapeleriaWebApp.Controllers
{
    public class PedidoController : Controller
    {
        private IServicioCliente _servicioCliente;
        private IServicioArticulo _servicioArticulo;
        private IServicioPedidoExpress _servicioPedidoExpress;
        private IServicioPedidoComun _servicioPedidoComun;
        private IServicioPedido _servicioPedido;

        public PedidoController(IServicioCliente servicioCliente, IServicioArticulo servicioArticulo, IServicioPedidoExpress servicioPedidoExpress, IServicioPedidoComun servicioPedidoComun, IServicioPedido servicioPedido)
        {
            _servicioCliente = servicioCliente;
            _servicioArticulo = servicioArticulo;
            _servicioPedidoExpress = servicioPedidoExpress;
            _servicioPedidoComun = servicioPedidoComun;
            _servicioPedido = servicioPedido;
        }

        public ActionResult Crear()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            ViewBag.Clientes = _servicioCliente.GetAll();
            ViewBag.Articulos = _servicioArticulo.GetAll();
            var viewModel = new PedidoViewModel
            {
                FechaPedido = DateTime.Today,
                LineasPedido = new List<LineaPedidoViewModel>()
            };
            ViewBag.MostrarClientes = new SelectList(ViewBag.Clientes, "Id", "RazonSocial");
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Crear(PedidoViewModel viewModel, string tipoPedido)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            try
            {
                if (tipoPedido == "express")
                {
                    var nuevoPedido = new PedidoExpressDto
                    {
                        ClienteId = viewModel.ClienteId,
                        FechaPedido = viewModel.FechaPedido,
                        FechaEntrega = viewModel.FechaEntrega,
                        LineaPedidosDto = viewModel.LineasPedido.Select(linea => new LineaPedidoDto
                        {
                            ArticuloId = linea.ArticuloId,
                            UnidadesPedidas = linea.UnidadesPedidas,
                            PrecioUnitario = linea.PrecioUnitario
                        }).ToList()
                    };
                    
                    double totalPedido = _servicioPedidoExpress.CalcularTotal(nuevoPedido);
                    _servicioPedidoExpress.Add(nuevoPedido);

                    return RedirectToAction("Crear");
                }
                else if (tipoPedido == "comun")
                {
                    var nuevoPedido = new PedidoComunDto
                    {
                        ClienteId = viewModel.ClienteId,
                        ClienteDto = _servicioCliente.Get(viewModel.ClienteId),
                        FechaPedido = viewModel.FechaPedido,
                        FechaEntrega = viewModel.FechaEntrega,
                        LineaPedidosDto = viewModel.LineasPedido.Select(linea => new LineaPedidoDto
                        {
                            ArticuloId = linea.ArticuloId,
                            UnidadesPedidas = linea.UnidadesPedidas,
                            PrecioUnitario = linea.PrecioUnitario
                        }).ToList()
                    };
                    
                    double totalPedido = _servicioPedidoComun.CalcularTotal(nuevoPedido);
                    _servicioPedidoComun.Add(nuevoPedido);

                    return RedirectToAction("Crear");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return View("Crear");
        }
        public ActionResult Confirmar(PedidoViewModel viewModel, string tipoPedido)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            double totalPedido = 0;
            try { 
                if (tipoPedido == "express")
                {
                    var nuevoPedido = new PedidoExpressDto
                    {
                        ClienteId = viewModel.ClienteId,
                        FechaPedido = viewModel.FechaPedido,
                        FechaEntrega = viewModel.FechaEntrega,
                        LineaPedidosDto = viewModel.LineasPedido.Select(linea => new LineaPedidoDto
                        {
                            ArticuloId = linea.ArticuloId,
                            UnidadesPedidas = linea.UnidadesPedidas,
                            PrecioUnitario = linea.PrecioUnitario
                        }).ToList()
                    };
                    totalPedido = _servicioPedidoExpress.CalcularTotal(nuevoPedido);
                }
                else if (tipoPedido == "comun")
                {
                    var nuevoPedido = new PedidoComunDto
                    {
                        ClienteId = viewModel.ClienteId,
                        ClienteDto = _servicioCliente.Get(viewModel.ClienteId),
                        FechaPedido = viewModel.FechaPedido,
                        FechaEntrega = viewModel.FechaEntrega,
                        LineaPedidosDto = viewModel.LineasPedido.Select(linea => new LineaPedidoDto
                        {
                            ArticuloId = linea.ArticuloId,
                            UnidadesPedidas = linea.UnidadesPedidas,
                            PrecioUnitario = linea.PrecioUnitario
                        }).ToList()
                    };
                    totalPedido = _servicioPedidoComun.CalcularTotal(nuevoPedido);
                }
                ViewBag.TotalPedido = totalPedido;
                ViewBag.TipoPedido = tipoPedido;
            }
            catch (Exception ex) 
            {
                TempData["Error"] = ex.Message;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ConfirmarPedido(PedidoViewModel viewModel, string tipoPedido)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            try
            {
                if (tipoPedido == "express")
                {
                    var nuevoPedido = new PedidoExpressDto
                    {
                        ClienteId = viewModel.ClienteId,
                        FechaPedido = viewModel.FechaPedido,
                        FechaEntrega = viewModel.FechaEntrega,
                        LineaPedidosDto = viewModel.LineasPedido.Select(linea => new LineaPedidoDto
                        {
                            ArticuloId = linea.ArticuloId,
                            UnidadesPedidas = linea.UnidadesPedidas,
                            PrecioUnitario = linea.PrecioUnitario
                        }).ToList()
                    };
                    _servicioPedidoExpress.Add(nuevoPedido);
                    TempData["Exito"] = "Pedido creado correctamente";
                }
                else if (tipoPedido == "comun")
                {
                    var nuevoPedido = new PedidoComunDto
                    {
                        ClienteId = viewModel.ClienteId,
                        ClienteDto = _servicioCliente.Get(viewModel.ClienteId),
                        FechaPedido = viewModel.FechaPedido,
                        FechaEntrega = viewModel.FechaEntrega,
                        LineaPedidosDto = viewModel.LineasPedido.Select(linea => new LineaPedidoDto
                        {
                            ArticuloId = linea.ArticuloId,
                            UnidadesPedidas = linea.UnidadesPedidas,
                            PrecioUnitario = linea.PrecioUnitario
                        }).ToList()
                    };
                    _servicioPedidoComun.Add(nuevoPedido);
                    TempData["Exito"] = "Pedido creado correctamente";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Crear");
        }

        public IActionResult AnulacionPedido()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            return View(new AnularPedidoViewModel());
        }

        [HttpPost]
        public IActionResult AnulacionPedido(AnularPedidoViewModel model)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            try
            {
                model.Pedidos = _servicioPedido.GetManyByDateNoAnulados(model.FechaPedido);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult AnularPedido(int pedidoId)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            try
            {
                PedidoDto pedidoParaAnular = _servicioPedido.GetById(pedidoId);
                _servicioPedido.UpdateAnular(pedidoParaAnular);

                TempData["Exito"] = "Pedido anulado correctamente";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("AnulacionPedido");
        }
    }
}
