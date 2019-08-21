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
    public class AddExerciseModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;

        private readonly Data.ApplicationDbContext _context;

        public AddExerciseModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList TopicsSL { get; set; }
        [BindProperty]
        public Exercise Exercise { get; set; }
        public IActionResult OnGet()
        {
            {
                if (!isAdmin)
                {
                    Message = "Sorry! You are not an Authorized person for this Page.";
                }
                else
                {
                    Message = "Welcome Admin!";
                    TopicsSL = new SelectList(_context.Topics.AsNoTracking().OrderBy(t => t.TitleEnglish), "ID", "TitleEnglish");
                }
                return Page();
            }
        }
            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                /* _context.Courses.Add(Course);
                 await _context.SaveChangesAsync();

                 return RedirectToPage("./Index");*/
                var emptyExercise = new Exercise();

                if (await TryUpdateModelAsync<Exercise>(
                     emptyExercise,
                     "exercise",   // Prefix for form value.
                     s => s.TitleEnglish, s => s.TitleFrench, s => s.TopicID, s => s.Description))
                {
                    _context.Exercise.Add(emptyExercise);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./ListExersice");
                }

                // Select TopicID if TryUpdateModelAsync fails.
                TopicsSL = new SelectList(_context.Topics, "ID", "Title");
                return Page();
            }
    } 


}