using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFrench.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyFrench.Pages.Admin.ManageExersice
{
    public class EditExerciseModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;

        private readonly Data.ApplicationDbContext _context;

        public EditExerciseModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList TopicsSL { get; set; }
        [BindProperty]
        public Exercise Exercise { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            if (!isAdmin)
            {
               Message = "Sorry! You are not an Authorized person for this Page.";
            }
            else
            {
               Message = "Welcome Admin!";
               Exercise = await _context.Exercise
               .Include(c => c.Topic).FirstOrDefaultAsync(m => m.ID == id);
               TopicsSL = new SelectList(_context.Topics.AsNoTracking().OrderBy(t => t.TitleEnglish), "ID", "TitleEnglish");
            }
            return Page();
            
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var exToUpdate = await _context.Exercise.FindAsync(id);

            if (await TryUpdateModelAsync<Exercise>(
                 exToUpdate,
                 "exercise",   // Prefix for form value.
                     s => s.TitleEnglish, s => s.TitleFrench, s => s.TopicID, s => s.Description))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./ListExersice");
            }           
            // Select TopicID if TryUpdateModelAsync fails.
            TopicsSL = new SelectList(_context.Topics, "ID", "Title");
            return Page();
        }
           

    }
}