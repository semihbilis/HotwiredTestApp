using System.ComponentModel.DataAnnotations;

namespace HotwiredTestApp.Models
{
    public class CardType : IEntity
    {
        private static int _CartTypeLastId = 1;

        public int Id { get; private set; } = _CartTypeLastId;
        public string Definition { get; set; } = string.Empty;
        public bool Visitiable { get; set; } = false;
        public bool LocationRequired { get; set; } = false;
        public bool UserAccount { get; set; } = false;

        public CardType()
        {
        }
        public CardType(int id)
        {
            Id = id;
        }
        public CardType(string definition, bool visitable = false, bool locationRequired = false, bool userAccount = false) : base()
        {
            _CartTypeLastId++;
            Id = _CartTypeLastId;
            Definition = definition;
            Visitiable = visitable;
            LocationRequired = locationRequired;
            UserAccount = userAccount;
        }
    }
}
