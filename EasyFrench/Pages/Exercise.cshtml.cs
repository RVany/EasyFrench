using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFrench.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyFrench.Pages.Admin
{
    public class ExerciseModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public ExerciseModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<TopicLevel> TopicLevels { get; set; }
        public IList<Exercise> Exercises { get; set; }
        public List<Topic> Topics { get; set; }
        public string cssClass { get; set; }

     
        public Level Level { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, string cssclass = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            cssClass = cssclass;
            Level = await _context.Levels.Include(c => c.QuestionsLevels).FirstOrDefaultAsync(m => m.ID == id);
            TopicLevels = await _context.TopicLevel
                          .Where(tl => tl.LevelID == id)
                          .ToListAsync();
            Topics = new List<Topic>();
            foreach(var topiclevel in TopicLevels)
            {
                var newTopic = await _context.Topics
                          .FirstOrDefaultAsync(m => m.ID == topiclevel.TopicID );
                Topics.Add(newTopic);
            }
            Exercises = await _context.Exercise.Include(q => q.Questions)
                    .ThenInclude(ql => ql.QuestionLevels).ToListAsync();
            return Page();
        }

    }
}