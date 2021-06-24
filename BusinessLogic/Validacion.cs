using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Validacion<T>: IValidacion<T> where T: class
    {
        public bool Validar(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new Exception("El objeto es inválido");
                }

                if (entity.GetType().GetProperties()
                        .Where(x => x.Name != "id")
                        .Select(x => x.GetValue(entity) == null ? throw new Exception("El valor de un campo es inválido") : x.GetValue(entity).ToString())
                        .Any(x => string.IsNullOrWhiteSpace(x)))
                {
                    return false;
                }
                return false;      
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
    }
}
