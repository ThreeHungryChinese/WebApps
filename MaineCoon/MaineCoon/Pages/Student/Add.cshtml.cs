using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaineCoon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaineCoon.Pages.Student
{
    public class AddApplyModel : PageModel {
        private readonly MaineCoon.Data.MaineCoonContext _context;
        public AddApplyModel(MaineCoon.Data.MaineCoonContext context) {
            _context = context;
        }
        public IActionResult OnGet() {
            ProgramList = new Dictionary<int, string>();
            var programs = _context.UniversityPrograms.Where(p => p.IsEnabled == true);
            foreach (var program in programs) {
                ProgramList.Add(program.Id, program.ProgramName);
            }
            return Page();
        }
        [BindProperty]
        public StudentScore studentScore { get; set; }
        [BindProperty]
        public int ProgramApplying { get; set; }
        public Dictionary<int, string> ProgramList;
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            //processorInfo.isTrained = false;
            //_context.Processers.Add(processorInfo);
            //await _context.SaveChangesAsync();
            

            return Redirect("./Develop/Index?message=Succeed!");
        }
    }
}