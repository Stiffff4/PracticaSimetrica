using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess.IBaseDelete
{
    public interface IBaseDelete<T> where T: class
    {
        bool Eliminar(int id);
        Task<bool> EliminarAsync(int id);
    }
}
