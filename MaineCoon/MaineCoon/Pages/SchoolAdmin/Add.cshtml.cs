using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MaineCoon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaineCoon.Pages.SchoolAdmin
{
    public class AddProgramModel : PageModel {
        private readonly MaineCoon.Data.MaineCoonContext _context;
        public AddProgramModel(MaineCoon.Data.MaineCoonContext context) {
            _context = context;
        }
        public IActionResult OnGet() {
            processers = new Dictionary<int, string>();
            foreach (var item in _context.Processers) {
                processers.Add(item.Id, item.friendlyName);
            }
            return Page();
        }
        [BindProperty]
        public UniversityProgram NewProgram { get; set; }
        public Dictionary<int,string> processers;
        public async Task<IActionResult> OnPostAsync() {
            if (_context.UniversityPrograms.Where(procer => procer.ProgramName == NewProgram.ProgramName).Any()) {
                throw new Exception("Processer Existed!");
            }
            else {
                NewProgram.BelongsToUserId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value);
                NewProgram.IsTrainNeeded = false;
                if (!ModelState.IsValid) {
                    return Page();
                }
                _context.UniversityPrograms.Add(NewProgram);
                await _context.SaveChangesAsync();
            }

            return Redirect("./"  +"/Index?message=Succeed!");
        }
    }
}