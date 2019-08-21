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
    public class EditQuestionModel : PageModel
    {
        public string Message = "";
        public bool isAdmin = Startup.isAdmin;

        private readonly Data.ApplicationDbContext _context;

        public EditQuestionModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList DifficultiesSL { get; set; }
        public SelectList ExerciesSL { get; set; }
        
        [BindProperty]
        public Question Question { get; set; }

        [BindProperty]
        public List<Answer> Answer { get; set; } = new List<Answer>();
        
        public List<Level> Levels { get; set; } = new List<Level>();

        /* [BindProperty]
         public Answer Answer2 { get; set; }
         [BindProperty]
         public Answer Answer3 { get; set; }
         [BindProperty]
         public Answer Answer4 { get; set; }
         */


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!isAdmin)
            {
                Message = "Sorry! You are not an Authorized person for this Page.";
            }
            else
            {
                Message = "Welcome Admin!";
                Question = await _context.Question
                    .Include(e => e.Exercise)
                       .ThenInclude(t => t.Topic)
                          .ThenInclude(tl => tl.TopicLevels)
                             .ThenInclude(l => l.Level)
                   .Include(ql => ql.QuestionLevels)
                   .Include(a => a.Answers)
                   .Include(d => d.Difficulty)
                   .FirstOrDefaultAsync(m => m.ID == id);
              
                foreach(var ans in Question.Answers)
                {
                    Answer.Add(ans);
                }
                foreach (var topiclevel in Question.Exercise.Topic.TopicLevels)
                {
                    var levelToAdd = await _context.Levels.FirstOrDefaultAsync(m => m.ID == topiclevel.LevelID);
                    Levels.Add(levelToAdd);
                }

                DifficultiesSL = new SelectList(_context.Difficulty.AsNoTracking().OrderBy(t => t.Points), "ID", "DifficultyLevel");
                ExerciesSL = new SelectList(_context.Exercise.AsNoTracking()
                   // .Include(t => t.Topic)
                    .Where(t => t.TopicID == Question.Exercise.TopicID)
                    .OrderBy(t => t.TitleEnglish), "ID", "TitleEnglish");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedLevels)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var quToUpdate = await _context.Question
                    .Include(e => e.Exercise)
                       .ThenInclude(t => t.Topic)
                          .ThenInclude(tl => tl.TopicLevels)
                             .ThenInclude(l => l.Level)
                   .Include(ql => ql.QuestionLevels)
                   .Include(a => a.Answers)
                   .Include(d => d.Difficulty)
                   .FirstOrDefaultAsync(m => m.ID == id);

            Message = "Welcome Admin!";
            if (await TryUpdateModelAsync<Question>(
                quToUpdate,
                "question",   // Prefix for form value.
                    s => s.QuestionEnglish, s => s.QuestionFrench, s => s.Description, s => s.ExerciseID,
                    s => s.DifficultyID))
            {
                await _context.SaveChangesAsync();
                quToUpdate = await _context.Question
                    .Include(e => e.Exercise)
                       .ThenInclude(t => t.Topic)
                          .ThenInclude(tl => tl.TopicLevels)
                             .ThenInclude(l => l.Level)
                   .Include(ql => ql.QuestionLevels)
                   .Include(a => a.Answers)
                   .Include(d => d.Difficulty)
                   .FirstOrDefaultAsync(m => m.ID == id);
                //return RedirectToPage("./ListQuestions");

            }

            var questionLevels = new HashSet<int>
                (quToUpdate.QuestionLevels               
                .Select(c => c.LevelID));

            foreach (var level in quToUpdate.Exercise.Topic.TopicLevels)
            {
                if (selectedLevels.Contains(level.LevelID.ToString()))
                {
                    if (!questionLevels.Contains(level.LevelID))
                    {
                        quToUpdate.QuestionLevels.Add(
                            new QuestionLevel
                            {
                                QuestionID = quToUpdate.ID,
                                LevelID = level.LevelID
                            });
                    }
                }
                else
                {
                    if (questionLevels.Contains(level.LevelID))
                    {

                        QuestionLevel levelToRemove
                            = quToUpdate
                                .QuestionLevels
                                .SingleOrDefault(c => c.LevelID == level.LevelID);
                        _context.Remove(levelToRemove);
                    }
                }
            }

            var i = 1;
            foreach (var ans in Answer)
                {
                var ansToUpdate = await _context.Answer.Where(a => a.ID == ans.ID).FirstOrDefaultAsync();

                ansToUpdate.AnswerText = ans.AnswerText;
                ansToUpdate.Status = ans.Status;

                await _context.SaveChangesAsync();
                if (i == 4)
                {
                    return RedirectToPage("./ListQuestions");
                }
                i++;
                /* if (await TryUpdateModelAsync<Answer>(
                  ansToUpdate,
                  "question",   // Prefix for form value.
                      s => s.AnswerText))
                 {

                     var testing = ansToUpdate.AnswerText;
                     await _context.SaveChangesAsync();
                     var testin2 = ansToUpdate.AnswerText;
                     if (i == 4)
                     {
                         return RedirectToPage("./ListQuestions");
                     }
                     i++;

                 }*/

            }

            // Select TopicID if TryUpdateModelAsync fails.
            DifficultiesSL = new SelectList(_context.Difficulty.AsNoTracking().OrderBy(t => t.Points), "ID", "DifficultyLevel");


            ExerciesSL = new SelectList(_context.Exercise.AsNoTracking()
                // .Include(t => t.Topic)
                //.Where(t => t.ID == Question.Exercise.TopicID)
                .OrderBy(t => t.TitleEnglish), "ID", "TitleEnglish");
            return Page();
        }

         public void UpdateAnswers(ApplicationDbContext context,
            string[] selectedLevels, Topic answersToUpdate)
         {
           
            
         }

    }
}