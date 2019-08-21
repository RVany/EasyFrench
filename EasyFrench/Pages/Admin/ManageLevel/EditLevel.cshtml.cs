using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFrench.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyFrench.Pages.Admin.ManageLevel
{
    [Authorize]
    public class EditLevelModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;
        private readonly Data.ApplicationDbContext _context;

        public EditLevelModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Level Level { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (!isAdmin)
            {
                Message = "Sorry! You are not an Authorized person for this Page.";
                return Page();
            }
            else
            {
                Message = "Welcome Admin!";

            }
           
            if (id == null)
            {
                return NotFound();
            }

            Level = await _context.Levels.FirstOrDefaultAsync(m => m.ID == id);

            if (Level == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Level).State = EntityState.Modified;

            try
            {
                if (IsUnique(Level.Title, Level.ID))
                {
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Message = "Title \"" + Level.Title + "\" is  Already Exist!";
                    return Page();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelExists(Level.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ListLevel");
        }

        private bool LevelExists(int id)
        {
            return _context.Levels.Any(e => e.ID == id);
        }
        private bool IsUnique(string _Title, int id)
        {
            return !_context.Levels.Any(e => e.Title == _Title && e.ID != id);
        }
    }

}