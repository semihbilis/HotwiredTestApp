using HotwiredTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotwiredTestApp.Pages
{
    public class CardTypesModel : PageModel
    {
        private readonly ILogger<CardTypesModel> _logger;
        private CardTypeRepository _cardTypeRepository = new CardTypeRepository();
        private const string locationTurboCardType = "TurboCardType/";
        private Random random = new Random();
        private bool randomBool { get { return random.Next() > Int32.MaxValue / 2 ? true : false; } }

        public CardTypesModel(ILogger<CardTypesModel> logger)
        {
            _logger = logger;
        }

        public PartialViewResult OnGetAddMoreAutomatic()
        {
            for (int i = 0; i < 20; i++)
            {
                string definition = "Definition " + i.ToString();
                CardType cardType = new CardType(definition, randomBool, randomBool, randomBool);
                _cardTypeRepository.Add(cardType);
            }
            return Partial(locationTurboCardType + "CardTypeList");
        }

        public PartialViewResult OnGetTotalCount()
        {
            int totalCount = _cardTypeRepository.GetAll().Count;
            Response.ContentType = "text/vnd.turbo-stream.html";
            return Partial(locationTurboCardType + "CardTypeCount", totalCount);
        }

        public PartialViewResult OnGetTypes()
        {
            return Partial(locationTurboCardType + "CardTypeList");
        }

        public PartialViewResult OnGetEdit(int id) // --------------- ÇALIŞMIYOR KONTROL EDİLECEK
        {
            CardType cardType = _cardTypeRepository.Get(id);
            return Partial(locationTurboCardType + "CardTypeAddEdit", cardType);
        }

        public PartialViewResult OnGetAdd()
        {
            CardType cardType = new CardType();
            return Partial(locationTurboCardType + "CardTypeAddEdit", cardType);
        }

        public PartialViewResult OnGetDelete(int id)
        {
            if (_cardTypeRepository.Delete(id))
            {
                Response.ContentType = "text/vnd.turbo-stream.html";
                return Partial(locationTurboCardType + "CardTypeDelete", id);
            }
            else
                return Partial(locationTurboCardType + "CardTypeList");
        }

        public PartialViewResult OnPostSave(int Id, string Definition, bool Visitiable, bool LocationRequired, bool UserAccount)
        {
            if (string.IsNullOrEmpty(Definition))
            {
                return Partial(locationTurboCardType + "CardTypeList");
            }
            CardType cardType = new CardType(Definition, Visitiable, LocationRequired, UserAccount, Id);
            Response.ContentType = "text/vnd.turbo-stream.html";
            if (Id == 0)
            {
                _cardTypeRepository.Add(cardType);
                return Partial(locationTurboCardType + "CardTypeAdd", cardType);
            }
            else
            {
                _cardTypeRepository.Update(cardType);
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
                    _Instance.Add(new CardType("Eczacı", true, locationRequired: true));
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