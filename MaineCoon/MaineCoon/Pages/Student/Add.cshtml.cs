using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MaineCoon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;

namespace MaineCoon.Pages.Student
{
    public class AddApplyModel : PageModel {
        private readonly MaineCoon.Data.MaineCoonContext _context;
        public AddApplyModel(MaineCoon.Data.MaineCoonContext context) {
            _context = context;
        }
        public IActionResult OnGet() {
            ProgramList = new Dictionary<int, string>();
            var programs = _context.UniversityPrograms.Where(p => p.IsEnabled == true);
            foreach (var program in programs) {
                ProgramList.Add(program.Id, program.ProgramName);
            }
            return Page();
        }
        [BindProperty]
        public StudentScore studentScore { get; set; }
        [BindProperty]
        public int ProgramApplying { get; set; }
        public Dictionary<int, string> ProgramList;
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            try {
                var processerId = _context.UniversityPrograms.Where(p => p.Id == ProgramApplying).FirstOrDefault().ProcesserId;
                var processerUrl = _context.Processers.Where(p => p.Id == processerId).FirstOrDefault().getResultURL;
                using(var httpClinet = new HttpClient()) {
                    string processerUrlstring = processerUrl.ToString() + String.Format("?data=[{0},{1},{2},{3},{4},{5},{6}]", studentScore.G, studentScore.T, studentScore.UR, studentScore.SOP, studentScore.LOR, studentScore.GPA, studentScore.RES);
                    var response = await httpClinet.GetAsync(processerUrlstring);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    responseBody = HttpUtility.UrlEncode(responseBody);
                    responseBody = HttpUtility.HtmlEncode(responseBody);
                    return Redirect("Result?resultArgs=" + String.Format("Your Score is {0}", responseBody));
                }
            }
            catch (Exception) {
                throw;
            }
            //processorInfo.isTrained = false;
            //_context.Processers.Add(processorInfo);
            //await _context.SaveChangesAsync();
            

            return Redirect("./Develop/Index?message=Succeed!");
        }
    }
}