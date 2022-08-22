using System.ComponentModel.DataAnnotations;

namespace HotwiredTestApp.Models
{
    public class CardType : IEntity
    {
        public int Id { get; private set; } = _CartTypeId;
        public string Definition { get; set; } = string.Empty;
        public bool IsVisitiable { get; set; } = false;
        public bool IsLocationRequired { get; set; } = false;
        public bool IsUserAccount { get; set; } = false;

        public CardType()
        {
        }
        public CardType(string definition, bool isVisitable = false, bool isLocationRequired = false, bool isUserAccount = false) : base()
        {
            _CartTypeId++;
            Id = _CartTypeId;
            Definition = definition;
            IsVisitiable = isVisitable;
            IsLocationRequired = isLocationRequired;
            IsUserAccount = isUserAccount;
        }

        private static int _CartTypeId = 0;
    }
}
