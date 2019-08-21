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
    public class EditTopicModel : TopicLevelsPageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;

        private readonly ApplicationDbContext _context;

        public EditTopicModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public  Topic Topic{ get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!isAdmin)
            {
                Message = "Sorry! You are not an Authorized person for this Page.";

            }
            else
            {
                Message = "Welcome Admin!";
                Topic = await _context.Topics
                    .Include(i => i.TopicLevels).ThenInclude(i => i.Level)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.ID == id);

                if (Topic == null)
                {
                    return NotFound();
                }

            }
            PopulateAssignedLevelData(_context, Topic);
            return Page();

        }
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedLevels)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var topicToUpdate = await _context.Topics
             .Include(i => i.TopicLevels)
                .ThenInclude(i => i.Level)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<Topic>(
                topicToUpdate,
                "Topic",
                i => i.TitleEnglish, i => i.TitleFrench,
                i => i.Description))
            {
                /*if (String.IsNullOrWhiteSpace(
                    instructorToUpdate.OfficeAssignment?.Location))
                {
                    instructorToUpdate.OfficeAssignment = null;
                }*/
                UpdateTopicLevels(_context, selectedLevels, topicToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./ListTopic");
            }
            UpdateTopicLevels(_context, selectedLevels, topicToUpdate);
            PopulateAssignedLevelData(_context, topicToUpdate);
            return Page();
        }
    }
}