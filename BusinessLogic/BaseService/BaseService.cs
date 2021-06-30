using Database.OperationResult;
using IBusinessLogic.IBaseService;
using System;
using IDataAccess.IBaseData;
using System.Net;

namespace BusinessLogic.BaseService
{
    public class BaseService<T>: IBaseService<T> where T: class
    {
        private readonly IOperationResult _op;
        private readonly IBaseData<T> _bd;
        private readonly IValidacion<T> _validacion;
        public BaseService(IOperationResult op, IBaseData<T> bd, IValidacion<T> validacion)
        {
            _op = op;
            _bd = bd;
            _validacion = validacion;
        }
        public virtual IOperationResult Agregar(T entity)
        {
            try
            {
                _validacion.Validar(entity);

                _op.GetSuccessOperation(_bd.Agregar(entity));
                _op.status = HttpStatusCode.Created;
            }
            catch (Exception e) 
            {
                _op.GetErrorOperation(e);
            }

            return _op;
        }   

        public virtual IOperationResult Obtener()
        {
            try 
            {
                _op.GetSuccessOperation(_bd.Obtener());
            }
            catch (Exception e)
            {
                _op.GetErrorOperation(e);
            }

            return _op;
        }

        public virtual IOperationResult ObtenerPorId(int id)
        {
            try 
            {
                _op.GetSuccessOperation(_bd.ObtenerPorId(id));
            }
            catch (Exception e)
            {
                _op.GetErrorOperation(e);
            }

            return _op;
        }

        public virtual IOperationResult Editar(T entity)
        {
            try 
            {
                _op.GetSuccessOperation(_bd.Editar(entity));
            }
            catch (Exception e)
            {
                _op.GetErrorOperation(e);
            }

            return _op;
        }

        public virtual IOperationResult Eliminar(int id)
        {
            try 
            {
                _op.GetSuccessOperation(_bd.Eliminar(id));
            }
            catch (Exception e)
            {
                _op.GetErrorOperation(e);
            }

            return _op;
        }
    }
}
