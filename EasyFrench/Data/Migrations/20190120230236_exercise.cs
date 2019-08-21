using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFrench.Data.Migrations
{
    public partial class exercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DifficultyLevel = table.Column<string>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.ID);
                    table.UniqueConstraint("AlternateKey_Title", x => x.Title);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleFrench = table.Column<string>(nullable: false),
                    TitleEnglish = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleFrench = table.Column<string>(nullable: false),
                    TitleEnglish = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TopicID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Exercise_Topic_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicLevel",
                columns: table => new
                {
                    TopicID = table.Column<int>(nullable: false),
                    LevelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicLevel", x => new { x.TopicID, x.LevelID });
                    table.ForeignKey(
                        name: "FK_TopicLevel_Level_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Level",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicLevel_Topic_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VideoID = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TopicID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Video_Topic_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionFrench = table.Column<string>(nullable: false),
                    QuestionEnglish = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExerciseID = table.Column<int>(nullable: false),
                    DifficultyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Question_Difficulty_DifficultyID",
                        column: x => x.DifficultyID,
                        principalTable: "Difficulty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Exercise_ExerciseID",
                        column: x => x.ExerciseID,
                        principalTable: "Exercise",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerText = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    QuestionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionLevel",
                columns: table => new
                {
                    QuestionID = table.Column<int>(nullable: false),
                    LevelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionLevel", x => new { x.QuestionID, x.LevelID });
                    table.ForeignKey(
                        name: "FK_QuestionLevel_Level_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Level",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionLevel_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionID",
                table: "Answer",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_TopicID",
                table: "Exercise",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_DifficultyID",
                table: "Question",
                column: "DifficultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ExerciseID",
                table: "Question",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionLevel_LevelID",
                table: "QuestionLevel",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_TopicLevel_LevelID",
                table: "TopicLevel",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Video_TopicID",
                table: "Video",
                column: "TopicID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "QuestionLevel");

            migrationBuilder.DropTable(
                name: "TopicLevel");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
