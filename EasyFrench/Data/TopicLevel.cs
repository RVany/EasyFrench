using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Data
{
    public class TopicLevel
    {
        public int TopicID { get; set; }
        public int LevelID { get; set; }
        public Topic Topic { get; set; }
        public Level Level { get; set; }
    }
}
