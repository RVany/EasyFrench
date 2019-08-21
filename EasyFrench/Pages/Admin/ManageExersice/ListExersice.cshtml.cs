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
    public class ListExersiceModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;

        private readonly Data.ApplicationDbContext _context;

        public ListExersiceModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        //public IList<Topic> Topic { get; set; }
        public PaginatedList<Exercise> Exercise { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            if (!isAdmin)
            {
                Message = "Sorry! You are not an Authorized person for this Page.";

            }
            else
            {
                Message = "Welcome Admin!";

                IQueryable<Exercise> exerciseIQ = _context.Exercise
                                           .Include(t => t.Topic)
                                              .ThenInclude(tl => tl.TopicLevels)
                                                 .ThenInclude(l => l.Level)
                                           .OrderBy(t => t.TitleEnglish);
                int pageSize = 6;
                Exercise = await PaginatedList<Exercise>.CreateAsync(exerciseIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            }
        }
    }
}