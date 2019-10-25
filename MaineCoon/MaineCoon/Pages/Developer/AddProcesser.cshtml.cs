using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaineCoon.Models;
using Microsoft.AspNetCore.Http;

namespace MaineCoon.Pages.Developer
{
    public class AddProcesserModel : PageModel
    {
        private readonly MaineCoon.Data.MaineCoonContext _context;
        public AddProcesserModel(MaineCoon.Data.MaineCoonContext context) {
            _context = context;
        }
        public IActionResult OnGet() {
            if (HttpContext.Session.GetInt32(StaticSetting.UserIdSessionKey) != null) {
                return Page();
            }
            else {
                return RedirectToPage("./Index");
            }
        }
        [BindProperty]
        public Processer processorInfo { get; set; }
        public async Task<IActionResult> OnPostAsync() {
            if (HttpContext.Session.GetInt32(StaticSetting.UserIdSessionKey) == null) {
                //if un-login
                return RedirectToPage("./Index");
            }

            if (_context.Processers.Where(procer => procer.friendlyName == processorInfo.friendlyName).Any()) {
                throw new Exception("Processer Existed!");
            }
            else {
                processorInfo.belongsToUserID = HttpContext.Session.GetInt32(StaticSetting.UserIdSessionKey).Value;
                processorInfo.isTrained = false;
                if (!ModelState.IsValid) {
                    return Page();
                }
                _context.Processers.Add(processorInfo);
                await _context.SaveChangesAsync();
            }

            return Redirect("./Develop/Index?message=Succeed!");
        }
    }
}