using HotwiredTestApp.Data;
using HotwiredTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotwiredTestApp.Pages
{
    public class CardTypesModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public CardTypeRepository CardTypeRepository = new CardTypeRepository();

        public CardTypesModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public PartialViewResult OnGetTypes()
        {
            return Partial("CardTypeList");
        }

        public PartialViewResult OnGetEdit(int id)
        {
            CardType cardType = CardTypeRepository.Get(id);
            return Partial("CardTypeAddEdit", cardType);
        }

        public PartialViewResult OnPostDelete(int id)
        {
            CardType cardType = CardTypeRepository.Get(id);
            CardTypeRepository.Delete(cardType);
            Response.ContentType = "text/vnd.turbo-stream.html";
            return Partial("CardTypeDelete", cardType);
        }

        public IActionResult OnGetAdd(int id)
        {
            CardType cardType = new CardType(id);
            return Partial("CardTypeAdd", cardType);
        }

        public PartialViewResult OnPostSave(int id, string Definition, bool Visitiable, bool LocationRequired, bool UserAccount)
        {
            bool addOrEdit = string.IsNullOrEmpty(Definition);
            CardType cardType = CardTypeRepository.CardTypeList.First(x => x.Id == id);
            cardType.Definition = Definition;
            cardType.Visitiable = Visitiable;
            cardType.LocationRequired = LocationRequired;
            cardType.UserAccount = UserAccount;
            if (addOrEdit)
                return Partial("CardTypeAdd", cardType);
            else
            {
                Response.ContentType = "text/vnd.turbo-stream.html";
                return Partial("CardTypeEdit", cardType);
            }
        }
    }
}
