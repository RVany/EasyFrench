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
    public class ListQuestionsModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;

        private readonly Data.ApplicationDbContext _context;

        public ListQuestionsModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        //public IList<Topic> Topic { get; set; }
        public PaginatedList<Question> Questions { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            if (!isAdmin)
            {
                Message = "Sorry! You are not an Authorized person for this Page.";

            }
            else
            {
                Message = "Welcome Admin!";

                IQueryable<Question> questionIQ = _context.Question
                                           .Include(e => e.Exercise)
                                              .ThenInclude(t => t.Topic)
                                                 .ThenInclude(tl => tl.TopicLevels)
                                                   .ThenInclude(l => l.Level)
                                            .Include(ql => ql.QuestionLevels )
                                            .Include(a => a.Answers)
                                            .Include(d => d.Difficulty)
                                           .OrderBy(t => t.Exercise.Topic.ID);
                int pageSize = 6;
                Questions = await PaginatedList<Question>.CreateAsync(questionIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            }
        }
    }
}