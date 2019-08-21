using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFrench.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyFrench.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Level> Level { get; set; }
        public IList<Topic> Topic { get; set; }
        public IList<TopicLevel> TopicLevel { get; set; }
        public IList<Exercise> Exercise { get; set; }

        public async Task OnGetAsync()
        {
            Level = await _context.Levels.Include(ql => ql.QuestionsLevels).ToListAsync();
            Topic = await _context.Topics.ToListAsync();
            TopicLevel = await _context.TopicLevel.ToListAsync();
            Exercise = await _context.Exercise
                .Include(q => q.Questions)
                    .ThenInclude(ql => ql.QuestionLevels)
                 .ToListAsync();
        }
    }
}
