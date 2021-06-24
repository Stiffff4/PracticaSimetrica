using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess.IBaseData
{
    public interface IBaseData<T> where T: class
    {
        bool Agregar(T entity);

        List<T> Obtener();
        
        T ObtenerPorId(int id);

        bool Editar(T entity);

        bool Eliminar(int id);
    }
}
