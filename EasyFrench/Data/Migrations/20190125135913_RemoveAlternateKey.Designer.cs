// <auto-generated />
using System;
using EasyFrench.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyFrench.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190125135913_RemoveAlternateKey")]
    partial class RemoveAlternateKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EasyFrench.Data.Answer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerText")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<int>("QuestionID");

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("EasyFrench.Data.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("EasyFrench.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<int>("ApplicationUserTypeID");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("JoinedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Province");

                    b.Property<string>("SchoolBoardName");

                    b.Property<string>("SchoolName");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(1)")
                        .HasDefaultValue("A");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserTypeID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("EasyFrench.Data.ApplicationUserType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("UserType")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("ApplicationUserType");
                });

            modelBuilder.Entity("EasyFrench.Data.Difficulty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired();

                    b.Property<int>("Points");

                    b.HasKey("ID");

                    b.ToTable("Difficulty");
                });

            modelBuilder.Entity("EasyFrench.Data.Exercise", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("TitleEnglish");

                    b.Property<string>("TitleFrench")
                        .IsRequired();

                    b.Property<int>("TopicID");

                    b.HasKey("ID");

                    b.HasIndex("TopicID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("EasyFrench.Data.Level", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("EasyFrench.Data.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("DifficultyID");

                    b.Property<int>("ExerciseID");

                    b.Property<string>("QuestionEnglish")
                        .IsRequired();

                    b.Property<string>("QuestionFrench")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("DifficultyID");

                    b.HasIndex("ExerciseID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("EasyFrench.Data.QuestionLevel", b =>
                {
                    b.Property<int>("QuestionID");

                    b.Property<int>("LevelID");

                    b.HasKey("QuestionID", "LevelID");

                    b.HasIndex("LevelID");

                    b.ToTable("QuestionLevel");
                });

            modelBuilder.Entity("EasyFrench.Data.Topic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("TitleEnglish");

                    b.Property<string>("TitleFrench")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("EasyFrench.Data.TopicLevel", b =>
                {
                    b.Property<int>("TopicID");

                    b.Property<int>("LevelID");

                    b.HasKey("TopicID", "LevelID");

                    b.HasIndex("LevelID");

                    b.ToTable("TopicLevel");
                });

            modelBuilder.Entity("EasyFrench.Data.Video", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("TopicID");

                    b.Property<string>("VideoID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("TopicID");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EasyFrench.Data.Answer", b =>
                {
                    b.HasOne("EasyFrench.Data.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyFrench.Data.ApplicationUser", b =>
                {
                    b.HasOne("EasyFrench.Data.ApplicationUserType", "ApplicationUserType")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("ApplicationUserTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyFrench.Data.Exercise", b =>
                {
                    b.HasOne("EasyFrench.Data.Topic", "Topic")
                        .WithMany("Exercises")
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyFrench.Data.Question", b =>
                {
                    b.HasOne("EasyFrench.Data.Difficulty", "Difficulty")
                        .WithMany("Questions")
                        .HasForeignKey("DifficultyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyFrench.Data.Exercise", "Exercise")
                        .WithMany("Questions")
                        .HasForeignKey("ExerciseID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyFrench.Data.QuestionLevel", b =>
                {
                    b.HasOne("EasyFrench.Data.Level", "Level")
                        .WithMany("QuestionsLevels")
                        .HasForeignKey("LevelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyFrench.Data.Question", "Question")
                        .WithMany("QuestionLevels")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyFrench.Data.TopicLevel", b =>
                {
                    b.HasOne("EasyFrench.Data.Level", "Level")
                        .WithMany("TopicLevels")
                        .HasForeignKey("LevelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyFrench.Data.Topic", "Topic")
                        .WithMany("TopicLevels")
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyFrench.Data.Video", b =>
                {
                    b.HasOne("EasyFrench.Data.Topic", "Topic")
                        .WithMany("Videos")
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("EasyFrench.Data.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EasyFrench.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EasyFrench.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("EasyFrench.Data.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyFrench.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EasyFrench.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
