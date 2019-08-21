using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFrench.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyFrench.Pages.Admin.ManageQuestion
{
    public class RemoveQuestionModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;
        private readonly ApplicationDbContext _context;

        public RemoveQuestionModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Question Question { get; set; }

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

            Question = await _context.Question
                .Include(c => c.Exercise)
                    .ThenInclude(t => t.Topic)
                .FirstOrDefaultAsync(m => m.ID == id);


            if (Question == null)
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

            Question = await _context.Question.FindAsync(id);

            if (Question != null)
            {
                _context.Question.Remove(Question);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./ListQuestions");
        }
    }
}