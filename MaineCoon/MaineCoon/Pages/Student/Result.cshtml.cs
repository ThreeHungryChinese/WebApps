using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaineCoon.Pages.Student
{
    public class ResultModel : PageModel {
        public IActionResult OnGet(string resultArgs) {
            ViewData["result"] = resultArgs;
            return Page();
        }
    }
}