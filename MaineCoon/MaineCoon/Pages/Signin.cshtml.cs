using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaineCoon.Data;
using MaineCoon.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MaineCoon.Pages
{
    public class SigninModel : PageModel {
        private readonly MaineCoon.Data.MaineCoonContext _context;

        public SigninModel(MaineCoon.Data.MaineCoonContext context) {
            _context = context;
        }
        public IActionResult OnGet(string message="") {
            ViewData["message"] = message;
            return Page();
        }

        [BindProperty]
        public User UserData { get; set; }
        public async Task<IActionResult> OnPostAsync() {

            using (HMACSHA256 hasher = new HMACSHA256()) {
                User getSaveUser = _context.User.Where(usr => usr.email == UserData.email).FirstOrDefault();
                if (getSaveUser != null) {
                    hasher.Key = getSaveUser.SALT;
                    byte[] password = hasher.ComputeHash(UserData.password);
                    if (getSaveUser.password.SequenceEqual<byte>(password)) {
                        //password correct
                        if(getSaveUser.accountStatus != 0) {
                            //SUCCESS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                            var claims = new List<Claim>{
                                new Claim(ClaimTypes.Name, getSaveUser.name),
                                new Claim(ClaimTypes.Email, getSaveUser.email),
                                new Claim(ClaimTypes.Role,getSaveUser.sysRole.ToString()),
                                new Claim(ClaimTypes.NameIdentifier,getSaveUser.Id.ToString())
                            };
                            var claimIdentity = new ClaimsIdentity(claims:claims, authenticationType: CookieAuthenticationDefaults.AuthenticationScheme);
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
                            return RedirectToPage("./" + getSaveUser.sysRole.ToString() + "/Index");
                        }
                        else {
                            //account is unactivited
                            throw new Exception("Account is banned!");
                        }
                    }
                    else {
                        throw new Exception("incorrect Password!");
                    }
                }
                else {
                    throw new Exception("Cannot find this user!");
                }
            }

            if (!ModelState.IsValid) {
                ViewData["message"] = "ModelState is Not Valid!";
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}