using System.Collections.Generic;

namespace Database.Models
{
    public class CandidatoEvaluacion
    {
        public Candidato candidato { get; set; }

        public Evaluacion evaluacion { get; set; }
        public List<Evaluacion> listaEvaluaciones { get; set; }
    }
}
