using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyFrench.Data
{
    public class ApplicationUserType
    {
        public int ID { get; set; }

        [Required]
        public string UserType { get; set; }

        public string Description { get; set; }

        //Navigation Property
        
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }


    }
}