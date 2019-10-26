using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MaineCoon.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
        }

        public IActionResult OnGet(string message="") {
            if (User.Identity.IsAuthenticated) {
                return Redirect("~/" +
                    User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value ??
                    ("Signin?message=" + message)
                    );
            }
            return Redirect("Signin?message=" + message);

        }
    }
}
