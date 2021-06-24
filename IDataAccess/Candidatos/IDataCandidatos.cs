using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccess.IBaseData;

namespace IDataAccess.Candidatos
{
    public interface IDataCandidatos: IBaseData<Candidato>
    {
        bool agregarCandidato(Candidato candidato);

        bool modificarCandidato(Candidato candidato);

        IEnumerable<Candidato> obtenerCandidatos();

        Candidato obtenerCandidatoPorId(int id);

        bool eliminarCandidato(int id);
    }
}
