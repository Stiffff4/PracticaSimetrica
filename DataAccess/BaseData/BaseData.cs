using IDataAccess.IBaseData;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Database.Data;
using System.Threading.Tasks;

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

        #region MetodosNoAsincronos
        public virtual bool Agregar(T entity)
        {
            using (var transaction = _context.Database.BeginTransaction()) {

                try
                {
                    _dbSet.Add(entity);
                    _context.SaveChanges();
                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e.GetBaseException();
                }
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
            using (var transaction = _context.Database.BeginTransaction()) {
                try
                {
                    if (entity == null)
                        throw new Exception("La entidad es nula");

                    _dbSet.Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e.GetBaseException();
                }
            }
        }

        public virtual bool Eliminar(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var entity = _dbSet.Find(id);
                    if (entity == null)
                        throw new Exception("No se encontró el registro");

                    _context.Remove(entity);
                    _context.SaveChanges();
                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e.GetBaseException();
                }
            }
        }

        #endregion

        #region MetodosAsincronos
        public async virtual Task<bool> AgregarAsync(T entity)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {
                    await _dbSet.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e.GetBaseException();
                }
            }
        }

        public async virtual Task<List<T>> ObtenerAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public async virtual Task<T> ObtenerPorIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public async virtual Task<bool> EditarAsync(T entity)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (entity == null)
                        throw new Exception("La entidad es nula");

                    _dbSet.Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e.GetBaseException();
                }
            }
        }

        public async virtual Task<bool> EliminarAsync(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var entity = await _dbSet.FindAsync(id);
                    if (entity == null)
                        throw new Exception("No se encontró el registro");

                    _context.Remove(entity);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e.GetBaseException();
                }
            }
        }

        #endregion
    }
}