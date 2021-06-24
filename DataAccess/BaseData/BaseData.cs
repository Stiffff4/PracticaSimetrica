using IDataAccess.IBaseData;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Data;

namespace DataAccess.BaseData
{
    public class BaseData<T>: IBaseData<T> where T: class
    {
        private readonly EvaluacionContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseData(EvaluacionContext db)
        {
            _context = db;
            _dbSet = _context.Set<T>();
        }

        public virtual bool Agregar(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public virtual List<T> Obtener()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }

        }

        public virtual T ObtenerPorId(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public virtual bool Editar(T entity)
        {
            try
            {
                if (entity == null)
                    throw new Exception("La entidad es nula");

                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public virtual bool Eliminar(int id)
        {
            try
            {
                var entity = _dbSet.Find(id);
                if (entity == null)
                    throw new Exception("No se encontró el registro");

                _context.Remove(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
    }
}
