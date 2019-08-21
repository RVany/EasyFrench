using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Data
{
    public class Level
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<QuestionLevel> QuestionsLevels { get; set; } //Navigation Property
        public ICollection<TopicLevel> TopicLevels { get; set; } //Navigation Property
        
    }
    
}
