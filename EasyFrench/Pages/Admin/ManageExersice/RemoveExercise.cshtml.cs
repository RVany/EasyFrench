using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFrench.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyFrench.Pages.Admin.ManageExersice
{
    public class RemoveExerciseModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;
        private readonly ApplicationDbContext _context;

        public RemoveExerciseModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exercise Exercise{ get; set; }

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

            Exercise = await _context.Exercise.FirstOrDefaultAsync(m => m.ID == id);


            if (Exercise == null)
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

           Exercise  = await _context.Exercise.FindAsync(id);

            if (Exercise != null)
            {
                _context.Exercise.Remove(Exercise);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./ListExersice");
        }
    }
}