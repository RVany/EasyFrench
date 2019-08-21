using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyFrench.Pages.Admin
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;
        public void OnGet()
        {
            if (!isAdmin)
            {
                Message = "Sorry! You are not an Authorized person for this Page!";

            }
            else
            {
                Message = "Welcome Admin!";
            }

        }
    }
}