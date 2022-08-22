using HotwiredTestApp.Models;

namespace HotwiredTestApp.Data
{
    public class CardTypeRepository : ICardTypeRepository
    {
        private static List<CardType> _CardTypeList = new List<CardType>();

        public CardTypeRepository()
        {
            _CardTypeList.Add(new CardType("Personel", isUserAccount: true));
            _CardTypeList.Add(new CardType("Eczacı", true, true));
            _CardTypeList.Add(new CardType("Doktor", true));
            _CardTypeList.Add(new CardType("Diğer"));
            _CardTypeList.Add(new CardType("Diş Hekimi", true));
            _CardTypeList.Add(new CardType("Yönetici", true, isUserAccount: true));
        }

        public CardType Add(CardType cardType)
        {
            _CardTypeList.Add(cardType);
            return cardType;
        }

        public bool Delete(CardType cardType) => _CardTypeList.Remove(cardType);

        public CardType Get(int id) => _CardTypeList.Find(c => c.Id == id) ?? new CardType();

        public List<CardType> GetAll() => _CardTypeList;

        public CardType Update(CardType cardType)
        {
            int cardIndex = _CardTypeList.FindIndex(c => c.Id == cardType.Id);
            _CardTypeList[cardIndex].Definition = cardType.Definition;
            _CardTypeList[cardIndex].IsVisitiable = cardType.IsVisitiable;
            _CardTypeList[cardIndex].IsLocationRequired = cardType.IsLocationRequired;
            _CardTypeList[cardIndex].IsUserAccount = cardType.IsUserAccount;
            return _CardTypeList[cardIndex];
        }
    }
}