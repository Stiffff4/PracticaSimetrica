using System;
using System.Collections.Generic;
using System.Linq;
using Database.Models;
using Database.Data;
using IDataAccess.Evaluaciones;

namespace DataAccess.Evaluaciones
{
    public class DataEvaluaciones: IDataEvaluaciones
    {
        private readonly EvaluacionContext _context;
        public DataEvaluaciones(EvaluacionContext db)
        {
            _context = db;
        }
        public CandidatoEvaluacion obtenerEvaluacion(int id)
        {
            try
            {
                var evaluacion = _context.Evaluaciones.Where(x => x.id_candidato == id).ToList();
                var candidato =  _context.Candidatos.First(x => x.id == id);

                var candidatoEvaluacion = new CandidatoEvaluacion();
                candidatoEvaluacion.evaluacion = new Evaluacion();
                List<Evaluacion> evaluaciones = new List<Evaluacion>();

                foreach (var item in evaluacion)
                {
                    evaluaciones.Add(item);
                }

                candidatoEvaluacion.evaluacion.id_candidato = id;
                candidatoEvaluacion.listaEvaluaciones = evaluaciones;
                candidatoEvaluacion.candidato = candidato;

                return candidatoEvaluacion;
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }
        public bool evaluarCandidato(Evaluacion evaluacion)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Evaluaciones.Add(evaluacion);
                    _context.SaveChanges();
                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e.InnerException ?? e;
                }
            }
        }

        public bool eliminarEvaluaciones(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var evaluacion = _context.Evaluaciones.Where(x => x.id_candidato == id).ToList();
                try
                {
                    if (evaluacion.Count < 1)
                    {
                        throw new Exception("No hay ninguna evaluacion");
                    }

                    foreach (var ev in evaluacion)
                    {
                        _context.Evaluaciones.Remove(ev);
                    }

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
    }
}
