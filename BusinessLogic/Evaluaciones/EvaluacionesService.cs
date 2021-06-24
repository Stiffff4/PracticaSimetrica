using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Data;
using Database.Models;
using IBusinessLogic.Evaluaciones;
using IDataAccess.Evaluaciones;
using Database.OperationResult;
using System.Net;

namespace BusinessLogic.Evaluaciones
{
    public class EvaluacionesService : IEvaluacionesService
    {
        private readonly IDataEvaluaciones _dataEvaluaciones;
        private readonly IOperationResult _operationResult;
        private readonly IValidacion<Evaluacion> _validacion;
        public EvaluacionesService(IDataEvaluaciones dataEvaluaciones, IOperationResult operationResult, IValidacion<Evaluacion> validacion)
        {
            _dataEvaluaciones = dataEvaluaciones;
            _operationResult = operationResult;
            _validacion = validacion;
        }
        public IOperationResult obtenerEvaluacion(int id)
        {
            try
            {
                _operationResult.GetSuccessOperation(_dataEvaluaciones.obtenerEvaluacion(id));
            }
            catch (Exception e)
            {
                _operationResult.GetErrorOperation(e);
            }

            return _operationResult;
        }

        public IOperationResult evaluarCandidato(Evaluacion evaluacion)
        {
            try
            {
                if (_validacion.Validar(evaluacion))
                    throw new Exception("Los valores no son válidos.");

                _operationResult.GetSuccessOperation(_dataEvaluaciones.evaluarCandidato(evaluacion));
                _operationResult.status = HttpStatusCode.Created;
            }
            catch (Exception e)
            {
                _operationResult.GetErrorOperation(e);
            }

            return _operationResult;
        }

        public IOperationResult eliminarEvaluaciones(int id)
        {
            try
            {
                if (id < 1)
                    throw new Exception("El id no es válido");


                _operationResult.GetSuccessOperation(_dataEvaluaciones.eliminarEvaluaciones(id));
            }
            catch (Exception e)
            {
                _operationResult.GetErrorOperation(e);
            }

            return _operationResult;
        }
    }
}