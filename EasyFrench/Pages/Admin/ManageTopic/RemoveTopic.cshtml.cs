using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFrench.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyFrench.Pages.Admin.ManageTopic
{
    public class RemoveTopicModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;

        private readonly ApplicationDbContext _context;

        public RemoveTopicModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Topic Topic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (!isAdmin)
            {
                Message = "Sorry! You are not an Authorized person for this Page.";

            }
            else
            {
                Message = "Welcome Admin!";

                if (id == null)
                {
                    return NotFound();
                }

                Topic = await _context.Topics.FirstOrDefaultAsync(m => m.ID == id);

                if (Topic == null)
                {
                    return NotFound();
                }

            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Topic topic = await _context.Topics
                .Include(i => i.TopicLevels)
                .SingleAsync(i => i.ID == id);

           /* var departments = await _context.Departments
                .Where(d => d.InstructorID == id)
                .ToListAsync();
            departments.ForEach(d => d.InstructorID = null);*/

            _context.Topics.Remove(topic);

            await _context.SaveChangesAsync();
            return RedirectToPage("./ListTopic");
        }
    }
}