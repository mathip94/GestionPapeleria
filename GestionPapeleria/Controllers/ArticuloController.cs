using Domain.Models;
using Domain.Dtos;
using GestionPapeleriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GestionPapeleriaWebApp.Controllers
{
    public class ArticuloController : Controller
    {
        private IServicioArticulo _servicioArticulo;

        public ArticuloController(IServicioArticulo servicioArticulo)
        {
            _servicioArticulo = servicioArticulo;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArticuloViewModel model)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var articuloDto = new ArticuloDto
                    {
                        Nombre = model.Nombre,
                        Descripcion = model.Descripcion,
                        Codigo = model.Codigo,
                        PrecioVenta = model.PrecioVenta,
                        Stock = model.Stock
                    };

                    _servicioArticulo.Add(articuloDto);

                    TempData["Exito"] = "Articulo creado correctamente";
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
                return RedirectToAction(nameof(Create));
            }
            return View(model);
        }
    }
}
