#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;

namespace CalunsagWebApplication.Areas.Identity.Pages.Account
{
    public class ClientModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userMan;
        private readonly IUserStore<IdentityUser> _useStor;
        private readonly SignInManager<IdentityUser> _signInMan;
        private readonly IUserEmailStore<IdentityUser> _emailStor;
        private readonly ILogger<ClientModel> _log;
        private readonly IEmailSender _emailSend;

        public ClientModel(
            UserManager<IdentityUser> userMan,
            IUserStore<IdentityUser> useStor,
            SignInManager<IdentityUser> signInMan,
            ILogger<ClientModel> log,
            IEmailSender emailSend)
        {
            _userMan = userMan;
            _useStor = useStor;
            _signInMan = signInMan;
            _emailStor = GetEmailStore();
            _log = log;
            _emailSend = emailSend;
        }
        [BindProperty]
        public InputsModel Inputs { get; set; }
        public string ReturnUrls { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputsModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrls = returnUrl;
            ExternalLogins = (await _signInMan.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInMan.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {

                    UserName = Inputs.Email,
                    Email = Inputs.Email,

                };


                var result = await _userMan.CreateAsync(user, Inputs.Password);

                if (result.Succeeded)
                {
                    _log.LogInformation("User created a new account with password.");

                    await _userMan.AddToRoleAsync(user, "client");

                    var userId = await _userMan.GetUserIdAsync(user);
                    var code = await _userMan.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSend.SendEmailAsync(Inputs.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userMan.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Inputs.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInMan.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser>? GetEmailStore()
        {
            if (!_userMan.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_useStor;
        }

    }
}
