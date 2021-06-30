using IDataAccess.IBaseCreate;
using IDataAccess.IBaseRead;
using IDataAccess.IBaseUpdate;
using IDataAccess.IBaseDelete;

namespace IDataAccess.IBaseData
{
    public interface IBaseData<T>: IBaseCreate<T>, IBaseRead<T>, IBaseUpdate<T>, IBaseDelete<T> where T: class
    {

    }
}
