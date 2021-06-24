using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBusinessLogic.Evaluaciones;
using Database.Models;
using IBusinessLogic.Candidatos;

namespace PracticaSimetrica.Controllers
{
    public class EvaluacionesController : Controller
    {
        private readonly IEvaluacionesService _serviceEvaluaciones;
        private readonly ICandidatosService _serviceCandidatos;


        public EvaluacionesController(IEvaluacionesService Eservice, ICandidatosService Cservice)
        {
            _serviceEvaluaciones = Eservice;
            _serviceCandidatos = Cservice;
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