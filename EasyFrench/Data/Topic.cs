using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Data
{
    public class Topic
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "French Title")]
        public string TitleFrench { get; set; }

        [Display(Name = "English Title")]
        public string TitleEnglish { get; set; }

        public string Description { get; set; }

        public ICollection<Exercise> Exercises { get; set; } //Navigation Property
        public ICollection<Video> Videos { get; set; }  //Navigation Property

        [Display(Name = "Topic Levels")]
        public ICollection<TopicLevel> TopicLevels { get; set; } //Navigation Property
    }
}
