using Microsoft.AspNetCore.Mvc;
using System;

namespace SistemaWebEmpleado.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Bienvenido al Sistema de Empleados";
            ViewBag.Fecha = DateTime.Now.ToString();
            return View();
        }
    }
}
