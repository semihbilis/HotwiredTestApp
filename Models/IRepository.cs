namespace HotwiredTestApp.Models
{
    public interface IRepository<T> where T : IEntity
    {
        List<T> GetAll();
        T Get(int id);
        T Add(T entity);
        T Update(T entity);
        bool Delete(int id);
    }
}
