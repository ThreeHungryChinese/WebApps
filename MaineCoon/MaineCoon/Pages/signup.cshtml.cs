using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaineCoon.Data;
using MaineCoon.Models;

namespace MaineCoon.Pages
{
    public class SignupModel : PageModel {
        private readonly MaineCoon.Data.UserContext _context;

        public SignupModel(MaineCoon.Data.UserContext context) {
            _context = context;
        }
        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public User UserData { get; set; }
        public async Task<IActionResult> OnPostAsync() {

            UserData.registionTime = DateTime.UtcNow;
            UserData.accountStatus = Models.User.status.Disable;
            if (!ModelState.IsValid) {
                return Page();
            }


            _context.User.Add(UserData);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}