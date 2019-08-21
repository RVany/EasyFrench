using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFrench.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyFrench.Pages.Admin.ManageLevel
{
    [Authorize]
    public class AddLevelModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;

        private readonly Data.ApplicationDbContext _context;

        public AddLevelModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            if (!isAdmin)
            {
                Message = "Sorry! You are not an Authorized person for this Page.";

            }
            else
            {
                Message = "Welcome Admin!";
                
            }
            return Page();
        }

        [BindProperty]
        public Level Level { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (IsUnique(Level.Title))
            {
                 _context.Levels.Add(Level);
                 await _context.SaveChangesAsync();
                 return RedirectToPage("./ListLevel");
            }
            else
            {
                Message = "Title \"" + Level.Title + "\" is  Already Exist!";
                return Page();
            }           
        }

        private bool IsUnique(string _Title)
        {
            return !_context.Levels.Any(e => e.Title == _Title);
        }
        private bool IsUnique2(string context, string entity, string property, string value)
        {
            var b = "!" + context + "." + entity + ".Any(e = e." + property + "==" + value + ")";
            // bool v = (b.Replace(""","")
            // bool b = Boolean.Parse("!" + context + "." + entity + ".Any(e = e." + property + "==" + value + ")");

            return Boolean.Parse(b);
            //"https://stackoverflow.com/questions/4800267/how-to-execute-code-that-is-in-a-string"
            // It's hard to change string to code in c#
        }
    }
}