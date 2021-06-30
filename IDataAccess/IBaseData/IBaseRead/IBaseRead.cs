using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess.IBaseRead
{
    public interface IBaseRead<T> where T: class
    {
        List<T> Obtener();
        T ObtenerPorId(int id);
        Task<List<T>> ObtenerAsync();
        Task<T> ObtenerPorIdAsync(int id);
    }
}
