using System.ComponentModel.DataAnnotations;

namespace HotwiredTestApp.Models
{
    public class CardType : IEntity
    {
        public static int _CartTypeLastId = 0;

        public int Id { get; private set; } = 0;
        public string Definition { get; set; } = string.Empty;
        public bool Visitiable { get; set; } = false;
        public bool LocationRequired { get; set; } = false;
        public bool UserAccount { get; set; } = false;

        public CardType()
        {
            Id = 0;
        }

        public CardType(string definition, bool visitable = false, bool locationRequired = false, bool userAccount = false, int id = 0)
        {
            _CartTypeLastId++;
            Id = id == 0 ? _CartTypeLastId : id;
            Definition = definition;
            Visitiable = visitable;
            LocationRequired = locationRequired;
            UserAccount = userAccount;
        }
    }
}
