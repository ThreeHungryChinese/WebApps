using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaineCoon.Data;
using MaineCoon.Models;
using System.Security.Cryptography;

namespace MaineCoon.Pages
{
    public class SigninModel : PageModel {
        private readonly MaineCoon.Data.UserContext _context;

        public SigninModel(MaineCoon.Data.UserContext context) {
            _context = context;
        }
        public IActionResult OnGet() {
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
                            //account is activited
                            return RedirectToPage("./" + getSaveUser.sysRole.ToString() + "/Index");
                        }
                        else {
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
                return Page();
            }


            _context.User.Add(UserData);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}