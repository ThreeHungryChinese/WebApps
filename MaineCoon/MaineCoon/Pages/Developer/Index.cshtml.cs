using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using MaineCoon.Models;


namespace MaineCoon.Pages.Developer
{
    public class IndexModel : PageModel {
        public IndexModel(MaineCoon.Data.MaineCoonContext context) {
            _context = context;
        }
        private readonly MaineCoon.Data.MaineCoonContext _context;
        public IActionResult OnGet(string message="")
        {
            ViewData["message"] = message;
            if (this.HttpContext.Session.GetInt32(StaticSetting.UserIdSessionKey) != null) {
                //logined
                var context = _context.Processers.Where(procer => procer.belongsToUserID == (HttpContext.Session.GetInt32(StaticSetting.UserIdSessionKey)));
                List<_Card> _Cards = new List<_Card>();
                foreach (var oneProcesser in context) {
                    var oneCard = new _Card();
                    oneCard.Head = oneProcesser.id.ToString();
                    oneCard.BodyTitle = oneProcesser.friendlyName;
                    oneCard.Body = string.Format("This processor has been called {0} times", 25);
                    oneCard.Btn0URL = Url.Content("/Developer/Edit");
                    oneCard.Btn0Label = "Edit";
                    oneCard.Btn1URL = Url.Content("/Developer/Reset");
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