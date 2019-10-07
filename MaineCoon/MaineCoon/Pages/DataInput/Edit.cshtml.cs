using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaineCoon.Data;
using MaineCoon.Models;

namespace MaineCoon.Pages.DataInput
{
    public class EditModel : PageModel
    {
        private readonly MaineCoon.Data.StudentScoreContext _context;

        public EditModel(MaineCoon.Data.StudentScoreContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentScore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentScoreExists(StudentScore.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentScoreExists(int id)
        {
            return _context.StudentScore.Any(e => e.id == id);
        }
    }
}
