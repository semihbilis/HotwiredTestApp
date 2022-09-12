using HotwiredTestApp.Pages;

namespace HotwiredTestApp.Models
{
    public class CardTypeRepository : ICardTypeRepository<CardType>
    {
        public bool Add(CardType cardType)
        {
            DataCardType.Instance.Add(cardType);
            return DataCardType.Instance.Any(c => c.Id == cardType.Id);
        }

        public bool Delete(int id)
        {
            CardType cardType = Get(id);
            return DataCardType.Instance.Remove(cardType);
        }

        public CardType Get(int id)
        {
            try
            {
                return DataCardType.Instance.First(c => c.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"Card type {id} not found.");
            }
        }

        public List<CardType> GetAll() => DataCardType.Instance;

        public CardType Update(CardType cardType)
        {
            Delete(cardType.Id);
            if (Add(cardType))
            {
                return cardType;
            }
            else
                throw new ArgumentException($"Card type {cardType.Id} not update.");
        }
    }
}