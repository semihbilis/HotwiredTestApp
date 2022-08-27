using HotwiredTestApp.Pages;

namespace HotwiredTestApp.Models
{
    public class CardTypeRepository : ICardTypeRepository<CardType>
    {
        public CardType Add(CardType cardType)
        {
            DataCardType.Instance.Add(cardType);
            return cardType;
        }

        public bool Delete(int id)
        {
            CardType cardType = Get(id);
            return DataCardType.Instance.Remove(cardType);
        }

        public CardType Get(int id) => DataCardType.Instance.FirstOrDefault(c => c.Id == id);

        public List<CardType> GetAll() => DataCardType.Instance;

        public CardType Update(CardType cardType)
        {
            CardType cT = DataCardType.Instance.First(c => c.Id == cardType.Id);
            cT.Definition = cardType.Definition;
            cT.Visitiable = cardType.Visitiable;
            cT.LocationRequired = cardType.LocationRequired;
            cT.UserAccount = cardType.UserAccount;
            return cT;
        }
    }
}