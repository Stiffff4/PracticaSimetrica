using Database.Models;
using Database.OperationResult;
using IBusinessLogic.IBaseService;

namespace IBusinessLogic.Candidatos
{
    public interface ICandidatosService: IBaseService<Candidato>
    {
        IOperationResult agregarCandidato(Candidato candidato);
        IOperationResult modificarCandidato(Candidato candidato);
        IOperationResult obtenerCandidatos();
        IOperationResult obtenerCandidatoPorId(int id);
        IOperationResult eliminarCandidato(int id);
    }
}
