using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calunsag_Final_IPT102.Pages
{
    [Authorize(Roles = "admin")]
    public class AdminModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
