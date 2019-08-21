using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Data
{
    public class QuestionLevel
    {
        public int QuestionID { get; set; }
        public int LevelID { get; set; }
        public Question Question { get; set; }
        public Level Level { get; set; }
    }
}
