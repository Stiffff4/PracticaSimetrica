using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess.IBaseCreate
{
    public interface IBaseCreate<T> where T: class
    {
        bool Agregar(T entity);
        Task<bool> AgregarAsync(T entity);
    }
}
