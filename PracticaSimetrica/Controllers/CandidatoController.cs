using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBusinessLogic.Candidatos;
using IBusinessLogic.Evaluaciones;
using Database.OperationResult;
using Database.Models;

namespace PracticaSimetrica.Controllers
{
    public class CandidatoController : BaseController<Candidato>
    {
        private readonly ICandidatosService _serviceCandidatos;
        private readonly IEvaluacionesService _serviceEvaluaciones;
        public CandidatoController(ICandidatosService serviceC, IEvaluacionesService serviceE)
            : base(serviceC)
        {
            _serviceCandidatos = serviceC;
            _serviceEvaluaciones = serviceE;
        }

        [HttpGet]
        public IActionResult RegistroCandidatos()
        {
            return View();
        }

        [HttpPost]
        public override IActionResult Agregar(Candidato candidato)
        {
            base.Agregar(candidato);
            return RedirectToAction("Obtener");
        }

        [HttpGet]
        public IActionResult ModificacionCandidato(int id)
        {
            var model = _serviceCandidatos.obtenerCandidatoPorId(id);

            return View(model.result);
        }

        [HttpPost]
        public IActionResult ModificacionCandidato(Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                _serviceCandidatos.modificarCandidato(candidato);
                return RedirectToAction("Obtener");
            }
            return View(candidato);
        }

        [HttpGet]
        public override IActionResult Eliminar(int id)
        {
            _serviceEvaluaciones.eliminarEvaluaciones(id);
            base.Eliminar(id);
            return RedirectToAction("Obtener");
        }
    }
}
