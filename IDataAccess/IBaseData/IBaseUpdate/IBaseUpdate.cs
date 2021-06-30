using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess.IBaseUpdate
{
    public interface IBaseUpdate<T> where T: class
    {
        bool Editar(T entity);
        Task<bool> EditarAsync(T entity);
    }
}
