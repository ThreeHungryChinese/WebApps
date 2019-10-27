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
    public class DetailsModel : PageModel
    {
        private readonly MaineCoon.Data.MaineCoonContext _context;

        public DetailsModel(MaineCoon.Data.MaineCoonContext context)
        {
            _context = context;
        }

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
    }
}
