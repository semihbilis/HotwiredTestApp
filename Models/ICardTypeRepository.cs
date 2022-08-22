namespace HotwiredTestApp.Models
{
    public interface ICardTypeRepository
    {
        List<CardType> GetAll();
        CardType Get(int id);
        CardType Add(CardType cardType);
        CardType Update(CardType cardType);
        bool Delete(CardType cardType);
    }
}
