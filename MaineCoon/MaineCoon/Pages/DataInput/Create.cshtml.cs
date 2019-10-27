using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MaineCoon.Data;
using MaineCoon.Models;
using System.Diagnostics;
using System.IO;

namespace MaineCoon.Pages.DataInput
{
    public class CreateModel : PageModel
    {
        private readonly MaineCoon.Data.MaineCoonContext _context;

        public CreateModel(MaineCoon.Data.MaineCoonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentScore StudentScore { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudentScore.Add(StudentScore);
            
            await _context.SaveChangesAsync();
            /*
            //https://medium.com/better-programming/running-python-script-from-c-and-working-with-the-results-843e68d230e5
            ProcessStartInfo processer = new ProcessStartInfo();
            processer.FileName = "/home/ubuntu/MaineCoon/DataProcesser/encapsulation.py";
            processer.Arguments = string.Format("python3 encapsulation.py {0} {1} {2} {3} {4} {5} {6}", StudentScore.T, StudentScore.G, StudentScore.UR, StudentScore.SOP, StudentScore.SOP, StudentScore.LOR, StudentScore.GPA, StudentScore.RES);
            processer.CreateNoWindow = false;
            processer.UseShellExecute = false;
            processer.RedirectStandardOutput = true;
            string score = "0.0 0.0";
            using (Process run = Process.Start(processer)) {
                using (StreamReader reader = run.StandardOutput) {
                    score = reader.ReadToEnd();
                }
            }
            */
            return RedirectToPage("./Index");
        }
    }
}
