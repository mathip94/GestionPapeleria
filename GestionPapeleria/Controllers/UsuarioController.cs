using Domain.Dtos;
using Domain.Models;
using GestionPapeleriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace GestionPapeleria.Controllers
{
    public class UsuarioController : Controller
    {
        private IServicioUsuario _servicioUsuario;

        public UsuarioController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            try
            {
                IEnumerable<UsuarioDtoSend> usuariosDto = _servicioUsuario.GetAll();
                IEnumerable<UsuarioIndexViewModel> usuariosViewModel = usuariosDto.Select(u => new UsuarioIndexViewModel
                {
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                });

                return View(usuariosViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioCreateViewModel viewModel)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioDto = new UsuarioDtoRead
                    {
                        Nombre = viewModel.Nombre,
                        Apellido = viewModel.Apellido,
                        Email = viewModel.Email,
                        Password = viewModel.Password
                    };
                    
                    _servicioUsuario.Add(usuarioDto);

                    TempData["Exito"] = "Usuario creado correctamente"; 

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Update(string email)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
                var usuarioDto = _servicioUsuario.GetByMail(email);
                var viewModel = new UsuarioUpdateViewModel
                {
                    Email = usuarioDto.Email,
                    Nombre = usuarioDto.Nombre,
                    Apellido = usuarioDto.Apellido
                };
                return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(UsuarioUpdateViewModel viewModel)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioDto = new UsuarioDtoRead
                    {
                        Nombre = viewModel.Nombre,
                        Apellido = viewModel.Apellido,
                        Email = viewModel.Email,
                        Password = viewModel.Password
                    };
                    
                    _servicioUsuario.Update(viewModel.Email, usuarioDto);

                    TempData["Exito"] = "Datos Actualizados correctamente";

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(string email)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            try
            {
                var viewModel = new UsuarioDeleteViewModel { Email = email };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string email)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("NoAutorizado");
            }
            try
            {
                _servicioUsuario.Remove(email);

                TempData["Exito"] = "Usuario borrado correctamente"; 

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarLogin(string email, string pass)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
                {
                    throw new Exception("Datos vacíos");
                }

                UsuarioDtoSend u = _servicioUsuario.Login(email, pass);
                if (u == null) throw new Exception("Email o contraseña incorrectos");

                HttpContext.Session.SetString("email", u.Email);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Login");
            }
        }

        public IActionResult Logout()
        {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
        }
    }
}
