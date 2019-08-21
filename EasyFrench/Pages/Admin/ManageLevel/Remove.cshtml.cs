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
    public class RemoveModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;
        private readonly ApplicationDbContext _context;

        public RemoveModel(ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Level = await _context.Levels.FindAsync(id);

            if (Level != null)
            {
                _context.Levels.Remove(Level);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ListLevel");
        }
    }
}