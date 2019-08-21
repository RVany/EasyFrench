using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFrench.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyFrench.Pages.Admin.ManageTopic
{
    public class AddTopicModel : TopicLevelsPageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;

        private readonly ApplicationDbContext _context;

        public AddTopicModel(ApplicationDbContext context)
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
                var topic = new Topic();
                topic.TopicLevels = new List<TopicLevel>();

                // Provides an empty collection for the foreach loop
                // foreach (var level in Model.AssignedLevelDataList)
                // in the AddTopic Razor page.
                PopulateAssignedLevelData(_context, topic);
            }
            
            return Page();
        }

        [BindProperty]
        public Topic Topic { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedLevels)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newTopic = new Topic();
            if (selectedLevels != null)
            {
                newTopic.TopicLevels = new List<TopicLevel>();
                foreach (var level in selectedLevels)
                {
                    var levelToAdd = new TopicLevel
                    {
                        LevelID = int.Parse(level)
                    };
                    newTopic.TopicLevels.Add(levelToAdd);
                }
            }

            if (await TryUpdateModelAsync<Topic>(
                newTopic,
                "Topic",
                i => i.TitleEnglish, i => i.TitleFrench,
                i => i.Description))
            {
                _context.Topics.Add(newTopic);
                await _context.SaveChangesAsync();
                return RedirectToPage("./ListTopic");
            }
            PopulateAssignedLevelData(_context, newTopic);
            return Page();
        }
    }
}