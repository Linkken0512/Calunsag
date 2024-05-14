using Calunsag_Final_IPT102.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calunsag_Final_IPT102.Pages
{
    [Authorize]
    public class bababaModel : PageModel
    {
        private readonly UserManager<AppUser> usersManager;

        public AppUser? appUser;

        public bababaModel(UserManager<AppUser> usersManager)
        {
            this.usersManager = usersManager;
        }
        public void OnGet()
        {
            var task = usersManager.GetUserAsync(User);
            task.Wait();
            appUser = task.Result;
        }
    }
}
