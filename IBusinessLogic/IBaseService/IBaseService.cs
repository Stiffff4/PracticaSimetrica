using Database.OperationResult;

namespace IBusinessLogic.IBaseService
{
    public interface IBaseService<T> where T: class
    {
        IOperationResult Agregar(T entity);

        IOperationResult Obtener();

        IOperationResult ObtenerPorId(int id);

        IOperationResult Editar(T entity);

        IOperationResult Eliminar(int id);
    }
}
