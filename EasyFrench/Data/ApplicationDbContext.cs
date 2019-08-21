using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyFrench.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUserType> ApplicationUserType { get; set; }
        public DbSet<ApplicationUser> ApplicationUser{ get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionLevel> QuestionLevel { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicLevel> TopicLevel { get; set; }       
        public DbSet<Video> Video { get; set; }        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            modelBuilder.Entity<Topic>().ToTable("Topic");
            modelBuilder.Entity<Level>().ToTable("Level");

            modelBuilder.Entity<ApplicationUser>()
           .Property(b => b.Status)
           .HasDefaultValue('A');

            modelBuilder.Entity<ApplicationUser>()
           .Property(b => b.JoinedDate)
           .HasDefaultValueSql("getdate()");

           /* modelBuilder.Entity<Level>()
            .HasAlternateKey(c => c.Title)
            .HasName("AlternateKey_Title");
            */

            modelBuilder.Entity<QuestionLevel>()
                .HasKey(c => new { c.QuestionID, c.LevelID });
            modelBuilder.Entity<TopicLevel>()
                .HasKey(c => new { c.TopicID, c.LevelID });
        }
    }
}
