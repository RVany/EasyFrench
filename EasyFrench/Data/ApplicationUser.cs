using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        [Column(TypeName = "CHAR(1)")]
        public string Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinedDate { get; set; }// = DateTime.Now;

       // [ForeignKey("ApplicationUserType")]
        public int ApplicationUserTypeID { get; set; }//Foreign Key
        public ApplicationUserType ApplicationUserType { get; set; } //Navigation Property

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string SchoolName { get; set; }
        public string SchoolBoardName { get; set; }

    }
}
