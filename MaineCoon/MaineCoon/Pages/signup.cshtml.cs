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
    public class SignupModel : PageModel {
        private readonly MaineCoon.Data.MaineCoonContext _context;

        public SignupModel(MaineCoon.Data.MaineCoonContext context) {
            _context = context;
        }
        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public User UserData { get; set; }
        public async Task<IActionResult> OnPostAsync() {

            if (_context.User.Where(usr => usr.email == UserData.email).Any()) {
                throw new Exception("User Already Existed!");
            }
            else {
                UserData.registionTime = DateTime.UtcNow;
                UserData.accountStatus = Models.User.status.Disable;
                using (HMACSHA256 hasher = new HMACSHA256()) {
                    new Random().NextBytes(hasher.Key);
                    UserData.password = hasher.ComputeHash(UserData.password);
                    UserData.SALT = hasher.Key;
                }
            }
            if (!ModelState.IsValid) {
                return Page();
            }


            _context.User.Add(UserData);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index?message=RegistSucceed!");
        }
    }
}