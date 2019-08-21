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
    public class VideosModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;


        public VideosModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<string> IDs = new List<string>();
        public List<string> ThumbIDs = new List<string>();
        public List<string> Titles = new List<string>();
        public string Message = "";

        
        public Level Level { get; set; }
        public Topic Topic { get; set; }
        public string cssClass { get; set; }

        public async Task SetupVideoSet(string search)
        {
            await Program.Videos.GrabVidsAndSetData(search);
        }
        public void GetVideoSet()
        {
            IDs = Program.Videos.VidIDs;
            Titles = Program.Videos.Titles;
            ThumbIDs = Program.Videos.Thumbs;
        }

        public async Task OnGetAsync(int? levelId, int? topicId, int video, string search = null,
            string cssclass = null)
        {

            
            Level = await _context.Levels.FirstOrDefaultAsync(m => m.ID == levelId);
            Topic = await _context.Topics.FirstOrDefaultAsync(m => m.ID == topicId);
            cssClass = cssclass;

            await SetupVideoSet(search);
            GetVideoSet();
            if (Program.Videos.VidIDs.Count == 0)
            {
                Message = null;
            }
            else
            {
                ViewData["current_video"] = IDs[video];
                ViewData["current_title"] = Titles[video];
            }            
        }
    }
}