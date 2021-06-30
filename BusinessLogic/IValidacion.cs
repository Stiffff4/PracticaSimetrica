namespace BusinessLogic
{
    public interface IValidacion<T> where T: class
    {
        bool Validar(T entity);
    }
}
