using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFrench.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyFrench.Pages.Admin.ManageQuestion
{
    public class AddQuestionModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;

        private readonly Data.ApplicationDbContext _context;

        public AddQuestionModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList TopicsSL { get; set; }
        public SelectList ExerciesSL { get; set; }
        public SelectList DifficultiesSL { get; set; }
        public string TopicOption { get; set; }
        [BindProperty]
        public Question Question { get; set; }
        [BindProperty]
        public List<Answer> Answer { get; set; } = new List<Answer>(4);

        public IList<Level> Levels { get; set; } //= new List<Level>();


        public IActionResult OnGet()
        {
            
            if (!isAdmin)
            {
                    Message = "Sorry! You are not an Authorized person for this Page.";
            }
                else
                {
                    Message = "Welcome Admin!";
                    TopicsSL = new SelectList( _context.Topics.AsNoTracking().OrderBy(t => t.TitleEnglish), "ID", "TitleEnglish");
                    TopicOption = "Select The Topic";
                // Levels =  await _context.Levels.ToListAsync();
               

                

            }
                return Page();            
        }

        public async Task<IActionResult> OnPostGetExercises(int topic)
        {
            Message = "Welcome Admin!";
            TopicsSL = new SelectList(_context.Topics.AsNoTracking().OrderBy(t => t.TitleEnglish), "ID", "TitleEnglish");
            //var curexes = new List<Exercise>(); ;
           // curexes = await _context.Exercise.Where(t => t.TopicID == topic).ToListAsync();
            //if (curexes.Count > 0)
           // {
                ExerciesSL = new SelectList(_context.Exercise.AsNoTracking()
                   // .Include(t => t.Topic)
                   .Where(t => t.TopicID == topic)
                   .OrderBy(t => t.TitleEnglish), "ID", "TitleEnglish");
            //}
            var curtopic = new Topic();
            curtopic = await _context.Topics.Include(tl => tl.TopicLevels).FirstOrDefaultAsync(m => m.ID == topic);
            TopicOption = curtopic.TitleEnglish;
            Levels = new List<Level>();

            foreach (var topiclevel in curtopic.TopicLevels)
            {
                var levelToAdd = await _context.Levels.FirstOrDefaultAsync(m => m.ID == topiclevel.LevelID);
               
                Levels.Add(levelToAdd);
            }

            DifficultiesSL = new SelectList(_context.Difficulty.AsNoTracking().OrderBy(t => t.Points), "ID", "DifficultyLevel");
            for (int i = 0; i < 4; i++)
            {
                var newAns = new Answer();

                Answer.Add(newAns);
            }
            return Page();

        }

        public async Task<IActionResult> OnPostAddQuestion(string[] selectedLevels)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var newQuestion = new Question();

            if (await TryUpdateModelAsync<Question>(
                 newQuestion,
                 "question",   // Prefix for form value.
                 s => s.QuestionEnglish, s => s.QuestionFrench, s => s.ExerciseID, s => s.DifficultyID, s => s.Description))
            {
                _context.Question.Add(newQuestion);

                foreach (var level in selectedLevels)
                {
                     _context.QuestionLevel.AddRange(
                            new QuestionLevel
                            {
                                QuestionID = newQuestion.ID,
                                LevelID = int.Parse(level)
                            });
                }               
                foreach (var ans in Answer)
                {
                    _context.Answer.AddRange(
                        new Answer
                        {
                            QuestionID = newQuestion.ID,
                            AnswerText = ans.AnswerText,
                            Status = ans.Status
                        });
                }
                await _context.SaveChangesAsync();
                return RedirectToPage("./ListQuestions");
            }

            // Select TopicID if TryUpdateModelAsync fails.
            TopicsSL = new SelectList(_context.Topics.AsNoTracking().OrderBy(t => t.TitleEnglish), "ID", "TitleEnglish");
            TopicOption = "Select The Topic";
            return Page();
        }
    }
}