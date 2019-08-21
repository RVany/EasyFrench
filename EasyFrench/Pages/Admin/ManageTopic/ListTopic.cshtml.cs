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
    public class ListTopicModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;

        private readonly Data.ApplicationDbContext _context;

        public ListTopicModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        //public IList<Topic> Topic { get; set; }
        public PaginatedList<Topic> Topic { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            if (!isAdmin)
            {
                Message = "Sorry! You are not an Authorized person for this Page.";

            }
            else
            {
                Message = "Welcome Admin!";

                IQueryable<Topic> topicIQ = _context.Topics
                                           .Include(tl => tl.TopicLevels)
                                              .ThenInclude(t => t.Level)
                                            .OrderBy(t => t.TitleEnglish);
                int pageSize = 6;
                Topic = await PaginatedList<Topic>.CreateAsync(topicIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            }

        }
    }
}