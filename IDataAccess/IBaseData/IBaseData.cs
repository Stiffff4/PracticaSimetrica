using IDataAccess.IBaseCreate;
using IDataAccess.IBaseRead;
using IDataAccess.IBaseUpdate;
using IDataAccess.IBaseDelete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess.IBaseData
{
    public interface IBaseData<T>: IBaseCreate<T>, IBaseRead<T>, IBaseUpdate<T>, IBaseDelete<T> where T: class
    {

    }
}
