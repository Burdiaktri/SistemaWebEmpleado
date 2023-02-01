using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly DBEmpleadosContext context;

        public EmpleadoController(DBEmpleadosContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var empleados = context.Empleados.ToList();
            return View(empleados);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Empleado empleado = new Empleado();
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        [HttpGet]
        public ActionResult GetByTitulo(string titulo)
        {
            Empleado empleado = GetEmpleadoByTitulo(titulo);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("GetByTitulo", empleado);
            }
        }

        [HttpGet]
        public ActionResult TraerUno(int id)
        {
            Empleado empleado = GetEmpleadoById(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("TraerUno", empleado);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Empleado empleado = GetEmpleadoById(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", empleado);
            }
        }

        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = GetEmpleadoById(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Empleado empleado = GetEmpleadoById(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("edit", empleado);
            }
        }


        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Entry(empleado).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        private Empleado GetEmpleadoById(int id)
        {
            return context.Empleados.Find(id);
        }

        private Empleado GetEmpleadoByTitulo(string titulo)
        {
            return context.Empleados.Find(titulo);
        }
    }
}
