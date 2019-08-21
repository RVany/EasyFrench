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
    public class QuestionModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public QuestionModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<TopicLevel> TopicLevels { get; set; }
        //public IList<Exercise> Exercises { get; set; }

        //public List<Topic> Topics { get; set; }

        public string cssClass { get; set; }
        //[BindProperty]
        public Level Level { get; set; }
        public Topic Topic { get; set; }
        public Exercise Exercise { get; set; }
        public Question Question { get; set; }
        public int _QNo { get; set; }
        public IList<QuestionLevel> QuestionLevels { get; set; }
        public List<Question> Questions { get; set; }
        public bool IsComplete { get; set; }
        public  string Message { get; set; }
        public int TotalScore { get; set; }
        public int CurrentScore { get; set; }

        public async Task<IActionResult> OnGetAsync(int QNo, int? levelId, int? topicId, int? exerciseId,
            string cssclass = null,string answer = null)
        {
            if (levelId == null | topicId == null | exerciseId == null)
            {
                return NotFound();
            }
            
            cssClass = cssclass;
            Level = await _context.Levels.FirstOrDefaultAsync(m => m.ID == levelId);
            Topic = await _context.Topics.FirstOrDefaultAsync(m => m.ID == topicId);
            Exercise = await _context.Exercise.FirstOrDefaultAsync(m => m.ID == exerciseId);

            Program.QuestionStore.CurrentScore = 0;
            //CurrentScore = Program.QuestionStore.CurrentScore;


            QuestionLevels = await _context.QuestionLevel
                      .Where(ql => ql.LevelID == levelId && ql.Question.ExerciseID == exerciseId)
                      .ToListAsync();
            if(QuestionLevels.Count == 0)
            {
                Message = "Sorry this exersice has no question!";
                return Page();
            }

            Questions = new List<Question>();
            foreach (var questionlevel in QuestionLevels)
            {
                var newQuestion = await _context.Question
                            .Where(q => q.ExerciseID == exerciseId).Include(t => t.Answers)
                            .Include(t => t.Difficulty)
                            .FirstOrDefaultAsync(m => m.ID == questionlevel.QuestionID);
                Questions.Add(newQuestion);
            }

            Program.QuestionStore.Questions = Questions;
            Question = Questions[QNo];
            getTotalScore();
            Program.QuestionStore.TotalScore = TotalScore;
            return Page();    
            
        }

        public void getTotalScore()
        {
            TotalScore = 0;
            foreach (var qu in Questions)
            {
                TotalScore += qu.Difficulty.Points;
            }
        }

        public async Task<IActionResult> OnPostAsync(int QNo, int? levelId, int? topicId, int? exerciseId,
            string cssclass = null, string answer = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            cssClass = cssclass;
            Level = await _context.Levels.FirstOrDefaultAsync(m => m.ID == levelId);
            Topic = await _context.Topics.FirstOrDefaultAsync(m => m.ID == topicId);
            Exercise = await _context.Exercise.FirstOrDefaultAsync(m => m.ID == exerciseId);

            Questions = Program.QuestionStore.Questions;

            _QNo = QNo;
            if (QNo < Questions.Count)
            {
                Question = Questions[QNo];
            }
            if (QNo > 0 && QNo <= Questions.Count)
            {
                foreach (var ans in Questions[QNo - 1].Answers)
                {
                    if (ans.AnswerText == answer)
                    {
                        if (ans.Status)
                        {
                            Program.QuestionStore.CurrentScore += Questions[QNo - 1].Difficulty.Points;
                            
                            ans.Status = false;
                        }
                    }
                }
            }
            if (QNo == Questions.Count)
            {
                Message = "Congratualations! You Complete the Exercise.";
                IsComplete = true;
            }
            CurrentScore = Program.QuestionStore.CurrentScore;
            getTotalScore();
            return Page();
        }
        }
    }