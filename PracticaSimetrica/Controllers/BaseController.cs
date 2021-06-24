using IBusinessLogic.IBaseService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaSimetrica.Controllers
{
    public class BaseController<T> : Controller where T: class
    {
        private readonly IBaseService<T> _bs;
        public BaseController(IBaseService<T> bs)
        {
            _bs = bs;
        }

        [HttpPost]
        public virtual IActionResult Agregar(T entity)
        {
            if (ModelState.IsValid)
            {
                _bs.Agregar(entity);
            }

            return View(entity);
        }

        [HttpGet]
        public IActionResult Obtener()
        {
            return View(_bs.Obtener().result);
        }

        [HttpGet]
        public IActionResult ObtenerPorId(int id)
        {
            return View(_bs.ObtenerPorId(id).result);
        }

        [HttpPost]
        public IActionResult Editar(T entity)
        {
            if (ModelState.IsValid)
            {
                _bs.Editar(entity);
            }

            return View();
        }

        [HttpGet]
        public virtual IActionResult Eliminar(int id)
        {
            _bs.Eliminar(id);
            return View();
        }
    }
}
