using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotwiredTestApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return RedirectToPage("Index");
            else
                return RedirectToPage("Main");
        }
    }
}