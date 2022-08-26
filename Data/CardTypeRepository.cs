using HotwiredTestApp.Models;

namespace HotwiredTestApp.Data
{
    public class CardTypeRepository : ICardTypeRepository
    {
        public List<CardType> CardTypeList = new List<CardType>();

        public CardTypeRepository()
        {
            CardTypeList.Add(new CardType("Personel", userAccount: true));
            CardTypeList.Add(new CardType("Eczacı", true, true));
            CardTypeList.Add(new CardType("Doktor", true));
            CardTypeList.Add(new CardType("Diğer"));
            CardTypeList.Add(new CardType("Diş Hekimi", true));
            CardTypeList.Add(new CardType("Yönetici", true, userAccount: true));
        }

        public CardType Add(CardType cardType)
        {
            CardTypeList.Add(cardType);
            return cardType;
        }

        public bool Delete(CardType cardType) => CardTypeList.Remove(cardType);

        public CardType Get(int id) => CardTypeList.First(c => c.Id == id) ?? new CardType();

        public List<CardType> GetAll() => CardTypeList;

        public CardType Update(CardType cardType)
        {
            CardType cT = CardTypeList.First(c => c.Id == cardType.Id);
            cT.Definition = cardType.Definition;
            cT.Visitiable = cardType.Visitiable;
            cT.LocationRequired = cardType.LocationRequired;
            cT.UserAccount = cardType.UserAccount;
            return cT;
        }
    }
}