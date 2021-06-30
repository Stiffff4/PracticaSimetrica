using Microsoft.AspNetCore.Mvc;
using IBusinessLogic.Evaluaciones;
using Database.Models;

namespace PracticaSimetrica.Controllers
{
    public class EvaluacionesController : Controller
    {
        private readonly IEvaluacionesService _serviceEvaluaciones;


        public EvaluacionesController(IEvaluacionesService Eservice)
        {
            _serviceEvaluaciones = Eservice;
        }

        [HttpGet]
        public IActionResult RegistroEvaluaciones(int id_candidato)
        {
            var model = _serviceEvaluaciones.obtenerEvaluacion(id_candidato).result;

            return View(model);
        }

        [HttpPost]
        public IActionResult RegistroEvaluaciones(CandidatoEvaluacion ev)
        {
            if (ModelState.IsValid)
            {
                _serviceEvaluaciones.evaluarCandidato(ev.evaluacion);
                return RedirectToAction("Obtener", "Candidato");
            }

            return View(ev);
        }

        [HttpGet]
        public IActionResult ObtenerEvaluacion(int id)
        {
            var resultado = _serviceEvaluaciones.obtenerEvaluacion(id).result;

            return View(resultado);
        }
    }
}