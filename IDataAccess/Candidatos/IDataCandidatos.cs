using Database.Models;
using System.Collections.Generic;
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
