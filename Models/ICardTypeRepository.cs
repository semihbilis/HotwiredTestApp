namespace HotwiredTestApp.Models
{
    public interface ICardTypeRepository<T> : IRepository<T> where T : IEntity
    {
    }
}
