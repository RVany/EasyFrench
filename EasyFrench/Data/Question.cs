using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Data
{
    public class Question
    {
        public int ID { get; set; }

        [Required]
        public string QuestionFrench { get; set; }
        [Required]
        public string QuestionEnglish { get; set; }


        public string Description { get; set; }
        
        public int ExerciseID { get; set; }
        public Exercise Exercise { get; set; }//navication property

        public int DifficultyID { get; set; }
        public Difficulty Difficulty { get; set; }//navication property


        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionLevel> QuestionLevels { get; set; }
    }
}
