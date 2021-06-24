using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Database.OperationResult;

namespace IBusinessLogic.Evaluaciones
{
    public interface IEvaluacionesService
    {
        IOperationResult obtenerEvaluacion(int id);
        IOperationResult evaluarCandidato(Evaluacion evaluacion);
        IOperationResult eliminarEvaluaciones(int id);
    }
}
