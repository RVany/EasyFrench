using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Data
{
    public class Answer
    {
        public int ID { get; set; }

        [Required]
        public string AnswerText { get; set; }
        [Required]
        public bool Status { get; set; }

        public string Description { get; set; }

        public int QuestionID { get; set; }
        public Question Question { get; set; }//navication property
    }
}
