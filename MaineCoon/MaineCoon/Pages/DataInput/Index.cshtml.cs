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
    public class IndexModel : PageModel
    {
        private readonly MaineCoon.Data.MaineCoonContext _context;

        public IndexModel(MaineCoon.Data.MaineCoonContext context)
        {
            _context = context;
        }

        public IList<StudentScore> StudentScore { get;set; }

        public async Task OnGetAsync(string score = "0.0 0.0")
        {
            ViewData["Score"] = score;
            StudentScore = await _context.StudentScore.ToListAsync();
        }
    }
}
