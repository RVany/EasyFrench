using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Data
{
    public class Difficulty
    {
        public int ID { get; set; }
        [Required]
        public string DifficultyLevel { get; set; }
        [Required]
        public int Points { get; set; }
        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }



    }
}
