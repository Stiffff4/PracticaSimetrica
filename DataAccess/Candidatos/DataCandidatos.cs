using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Data;
using Database.Models;
using IDataAccess.Candidatos;
using Microsoft.EntityFrameworkCore;
using DataAccess.BaseData;

namespace DataAccess.Candidatos
{
    public class DataCandidatos: BaseData<Candidato>, IDataCandidatos
    {
        private readonly EvaluacionContext _context;
        public DataCandidatos(EvaluacionContext db): base(db)
        {
            _context = db;
        }
        public bool agregarCandidato(Candidato candidato)
        {
            try
            {
                var resultado = _context.Candidatos.Add(candidato);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public bool modificarCandidato(Candidato candidato)
        {
            try
            {
                var resultado = _context.Candidatos.Find(candidato.id);

                if (resultado == null)
                    throw new Exception("No se encontró a ningún candidato con el id " + candidato.id);

                _context.Entry(resultado).CurrentValues.SetValues(candidato);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public IEnumerable<Candidato> obtenerCandidatos()
        {
            try
            {
                var resultado = _context.Candidatos.AsEnumerable();
                return resultado;
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public Candidato obtenerCandidatoPorId(int id)
        {
            {
                try
                {
                    var resultado = _context.Candidatos.Find(id);

                    if (resultado == null)
                        throw new Exception("No se encontró a ningún candidato con el id "+id);

                    return resultado;
                }
                catch (Exception e)
                {
                    throw e.GetBaseException();

                }
            }
        }

        public bool eliminarCandidato(int id)
        {
            var candidato = _context.Candidatos.Find(id);

            try
            {
                if (candidato != null)
                {
                    _context.Candidatos.Remove(candidato);

                    _context.SaveChanges();

                    return true;
                }

                else throw new Exception("No se encontro");
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
    }
}
