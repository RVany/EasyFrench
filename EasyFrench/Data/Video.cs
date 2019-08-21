using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Data
{
    public class Video
    {
        public int ID { get; set; }

        [Required]
        public string VideoID { get; set; }

        public string Description { get; set; }

        public int TopicID { get; set; }
        public Topic Topic { get; set; }//navication property
    }
}
