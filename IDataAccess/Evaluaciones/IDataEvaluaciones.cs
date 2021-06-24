using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;

namespace IDataAccess.Evaluaciones
{
    public interface IDataEvaluaciones
    {
        CandidatoEvaluacion obtenerEvaluacion(int id);

        bool evaluarCandidato(Evaluacion evaluacion);
        bool eliminarEvaluaciones(int id);
    }
}
