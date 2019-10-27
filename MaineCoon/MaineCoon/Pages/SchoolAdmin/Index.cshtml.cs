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
    public class IndexModel : PageModel {
        public IndexModel(MaineCoon.Data.MaineCoonContext context) {
            _context = context;
        }
        private readonly MaineCoon.Data.MaineCoonContext _context;
        public IActionResult OnGet(string message = "") {
            ViewData["message"] = message;
            if (this.User.Identity.IsAuthenticated) {
                //logined
                var currentUserId = Convert.ToInt32(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value ?? "-1");
                var context = _context.UniversityPrograms.Where(program => program.BelongsToUserId == currentUserId);
                List<_Card> _Cards = new List<_Card>();
                foreach (var program in context) {
                    var oneCard = new _Card();
                    oneCard.Head = program.Id.ToString();
                    oneCard.BodyTitle = program.ProgramName;
                    oneCard.Body = string.Format("This processor has been called {0} times", 25);
                    oneCard.Btn0URL = Url.Content("/" + User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value ?? "SchoolAdmin" + "/Edit");
                    oneCard.Btn0Label = "Edit";
                    oneCard.Btn1URL = Url.Content("/SchoolAdmin/Reset");
                    oneCard.Btn1Label = "Reset";
                    _Cards.Add(oneCard);
                }
                ViewData["CardList"] = _Cards;
                return Page();
            }
            else {
                return RedirectToPage("/Index");
            }
        }
    }
}