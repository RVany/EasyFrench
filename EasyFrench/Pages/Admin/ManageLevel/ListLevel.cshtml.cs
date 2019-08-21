using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFrench.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyFrench.Pages.Admin.ManageLevel
{
    [Authorize]
    public class ListLevelModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;
      
        private readonly Data.ApplicationDbContext _context;

        public ListLevelModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        //public IList<Level> Level { get; set; }
        public PaginatedList<Level> Level { get; set; }

      /*  public async Task OnGetAsync()
        {
            if (!isAdmin)
            {
                Message = "Sorry! You are not an Authorized person for this Page.";

            }
            else
            {
                Message = "Welcome Admin!";
                Level = await _context.Level.ToListAsync();
            }
        }*/
        public async Task OnGetAsync(int? pageIndex)
        {
            if (!isAdmin)
            {
                Message = "Sorry! You are not an Authorized person for this Page.";

            }
            else
            {
                Message = "Welcome Admin!";
                //IQueryable<Level> levelIQ = from t in _context.Level
                                           //  select t;

                IQueryable<Level> levelIQ = _context.Levels;
                int pageSize = 5;
                Level = await PaginatedList<Level>.CreateAsync(levelIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            }
        }
    }
}