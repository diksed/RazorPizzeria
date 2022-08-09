using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RazorPizzeria.Data;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace RazorPizzeria.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        //private readonly SignInManager<IdentityUser> SignInManager;
        //public LoginModel(SignInManager<IdentityUser> signInManager)
        //{
        //    this.SignInManager = signInManager;
        //}
        //public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var identityResult = await SignInManager.PasswordSignInAsync(Credential.UserName, Credential.Password, Credential.RememberMe, false);
        //        if (identityResult.Succeeded)
        //        {
        //            if(returnUrl == null || returnUrl == "/")
        //            {
        //                return RedirectToPage("Orders");
        //            }
        //            else
        //            {
        //                return RedirectToPage(returnUrl);
        //            }
        //        }
        //        ModelState.AddModelError("", "Username or password incorrect");
        //    }
        //    return Page();
        //}
        public void OnGet()
        {
        }
        [HttpGet]

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            if (Credential.UserName == "admin" && Credential.Password == "password")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("UserName", Credential.UserName));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, Credential.UserName));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToPage("/Orders");



                //var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name,"admin"),
                //    new Claim(ClaimTypes.Email,"admin@mywebsite.com"),
                //};

                //var identity = new ClaimsIdentity(claims,"MyCookieAuth");
                //var claimsPrincipal = new ClaimsPrincipal(identity);
                //await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                //return RedirectToPage("/Orders");
            }
            return Page();
        }
    }
    public class Credential
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
