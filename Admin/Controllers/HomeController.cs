using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Data.Repository;
using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        public readonly IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var empleado = _repo.GetAllEmpleados();
            return View(empleado);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new Empleado());
            }
            else
            {
                var empleado = _repo.GetEmpleado((int)id);
                return View(empleado);
            }
        }
            public async Task<IActionResult> Remove(int id)
            {
                _repo.RemoveEmpleado(id);
                await _repo.SaveChangesAsync();
                return RedirectToAction("Index");
            }

        [HttpPost]
        public async Task<IActionResult> Edit(Empleado empleado)
        {
            if (empleado.Id > 0)
                _repo.UpdateEmpleado(empleado);
            else
                _repo.AddEmpleado(empleado);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(empleado);
        }
    }
    
}