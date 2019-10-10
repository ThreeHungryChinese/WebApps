﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaineCoon.Data;
using MaineCoon.Models;

namespace MaineCoon.Pages
{
    public class SigninModel : PageModel {
        private readonly MaineCoon.Data.UserContext _context;

        public SigninModel(MaineCoon.Data.UserContext context) {
            _context = context;
        }
        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public User UserData { get; set; }
    }
}