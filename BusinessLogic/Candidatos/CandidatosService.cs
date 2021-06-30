using System;
using IBusinessLogic.Candidatos;
using Database.Models;
using IDataAccess.Candidatos;
using Database.OperationResult;
using System.Net;
using BusinessLogic.BaseService;

namespace BusinessLogic.Candidatos
{
    public class CandidatosService: BaseService<Candidato>, ICandidatosService
    {
        private readonly IDataCandidatos _dataCandidatos;
        private readonly IOperationResult _operationResult;
        private readonly IValidacion<Candidato> _validacion;
        public CandidatosService(IDataCandidatos dataCandidatos, IOperationResult operationResult, IValidacion<Candidato> validacion)
            : base(operationResult, dataCandidatos, validacion)
        {
            _dataCandidatos = dataCandidatos;
            _operationResult = operationResult;
            _validacion = validacion;
        }
        public IOperationResult agregarCandidato(Candidato candidato)
        {
            try
            {
                _validacion.Validar(candidato);

                _operationResult.GetSuccessOperation(_dataCandidatos.agregarCandidato(candidato));
                _operationResult.status = HttpStatusCode.Created;
            }
            catch (Exception e){
                _operationResult.GetErrorOperation(e);
            }

            return _operationResult;
        }

        public IOperationResult modificarCandidato(Candidato candidato)
        {
            try
            {
                _validacion.Validar(candidato);

                _operationResult.GetSuccessOperation(_dataCandidatos.modificarCandidato(candidato));
            }
            catch (Exception e)
            {
                _operationResult.GetErrorOperation(e);
            }

            return _operationResult;
        }

        public IOperationResult obtenerCandidatos()
        {
            try
            {
                _operationResult.GetSuccessOperation(_dataCandidatos.obtenerCandidatos());
            }
            catch (Exception e)
            {
                _operationResult.GetErrorOperation(e);
            }

            return _operationResult;
        }

        public IOperationResult obtenerCandidatoPorId(int id)
        {
            try
            {
                if (id < 1)
                    throw new Exception("El id no es válido");
                _operationResult.GetSuccessOperation(_dataCandidatos.obtenerCandidatoPorId(id));
            }
            catch (Exception e)
            {
                _operationResult.GetErrorOperation(e);
            }

            return _operationResult;
        }

        public IOperationResult eliminarCandidato(int id)
        {
            try
            {
                if (id < 1)
                    throw new Exception("El id no es válido");

                _operationResult.GetSuccessOperation( _dataCandidatos.eliminarCandidato(id));
            }
            catch (Exception e)
            {
                _operationResult.GetErrorOperation(e);
            }

            return _operationResult;
        }
    }
}
