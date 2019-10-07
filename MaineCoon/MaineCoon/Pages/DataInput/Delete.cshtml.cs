using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MaineCoon.Data;
using MaineCoon.Models;

namespace MaineCoon.Pages.DataInput
{
    public class DeleteModel : PageModel
    {
        private readonly MaineCoon.Data.StudentScoreContext _context;

        public DeleteModel(MaineCoon.Data.StudentScoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentScore StudentScore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentScore = await _context.StudentScore.FirstOrDefaultAsync(m => m.id == id);

            if (StudentScore == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentScore = await _context.StudentScore.FindAsync(id);

            if (StudentScore != null)
            {
                _context.StudentScore.Remove(StudentScore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
