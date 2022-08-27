using HotwiredTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;

namespace HotwiredTestApp.Pages
{
    public class CardTypesModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private CardTypeRepository _cardTypeRepository;
        private const string locationTurboCardType = "TurboCardType/";

        public CardTypesModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _cardTypeRepository = new CardTypeRepository();
        }

        public PartialViewResult OnGetTotalCount()
        {
            int totalCount = _cardTypeRepository.GetAll().Count;
            return Partial(locationTurboCardType + "CardTypeCount", totalCount);
        }

        public PartialViewResult OnGetTypes()
        {
            return Partial(locationTurboCardType + "CardTypeList");
        }

        public PartialViewResult OnGetEdit(int id)
        {
            CardType cardType = _cardTypeRepository.Get(id);
            return Partial(locationTurboCardType + "CardTypeAddEdit", cardType);
        }

        public PartialViewResult OnGetAdd()
        {
            CardType cardType = new CardType(0);
            return Partial(locationTurboCardType + "CardTypeAddEdit", cardType);
        }

        public PartialViewResult OnPostDelete(int id)
        {
            bool isSuccess = _cardTypeRepository.Delete(id);
            if (isSuccess)
                return Partial(locationTurboCardType + "CardTypeDelete", id);
            else
                return Partial(locationTurboCardType + "CardTypeList", this);
        }

        public PartialViewResult OnPostSave(int Id, string Definition, bool Visitiable, bool LocationRequired, bool UserAccount)
        {
            if (string.IsNullOrEmpty(Definition))
            {
                return Partial(locationTurboCardType + "CardTypeList", this);
            }
            if (Id == 0)
            {
                CardType newCardType = new CardType(Definition, Visitiable, LocationRequired, UserAccount);
                _cardTypeRepository.Add(newCardType);
                Response.ContentType = "text/vnd.turbo-stream.html";
                return Partial(locationTurboCardType + "CardTypeAdd", newCardType);
            }
            else
            {
                CardType cardType = _cardTypeRepository.Get(Id);
                cardType.Definition = Definition;
                cardType.Visitiable = Visitiable;
                cardType.LocationRequired = LocationRequired;
                cardType.UserAccount = UserAccount;
                _cardTypeRepository.Update(cardType);
                Response.ContentType = "text/vnd.turbo-stream.html";
                return Partial(locationTurboCardType + "CardTypeEdit", cardType);
            }
        }
    }

    public class DataCardType
    {
        private static List<CardType> _Instance = null;
        public static List<CardType> Instance
        {
            get
            {
                if (_Instance is null)
                {
                    _Instance = new List<CardType>();
                    _Instance.Add(new CardType("Personel", userAccount: true));
                    _Instance.Add(new CardType("Eczacı", true, true));
                    _Instance.Add(new CardType("Doktor", true));
                    _Instance.Add(new CardType("Diğer"));
                    _Instance.Add(new CardType("Diş Hekimi", true));
                    _Instance.Add(new CardType("Yönetici", true, userAccount: true));
                }
                return _Instance;
            }
        }
    }
}
