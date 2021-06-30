using System.Threading.Tasks;

namespace IDataAccess.IBaseUpdate
{
    public interface IBaseUpdate<T> where T: class
    {
        bool Editar(T entity);
        Task<bool> EditarAsync(T entity);
    }
}
