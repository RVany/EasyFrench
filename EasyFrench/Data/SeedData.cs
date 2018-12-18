using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any record.
                if (context.ApplicationUserType.Any())
                {
                    return;   // DB has been seeded
                }

                context.ApplicationUserType.AddRange(
                    new ApplicationUserType
                    {
                        UserType = "Student"
                    },

                    new ApplicationUserType
                    {
                        UserType = "Parent"
                    },
                    new ApplicationUserType
                    {
                        UserType = "Teacher"
                    },
                    new ApplicationUserType
                    {
                        UserType = "Principal"
                    },
                    new ApplicationUserType
                    {
                        UserType = "SchoolBoardMember"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
