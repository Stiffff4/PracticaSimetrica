using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class CandidatoEvaluacion
    {
        public Candidato candidato { get; set; }

        public Evaluacion evaluacion { get; set; }
        public List<Evaluacion> listaEvaluaciones { get; set; }
    }
}
