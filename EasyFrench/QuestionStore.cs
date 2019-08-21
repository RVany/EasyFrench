using EasyFrench.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench
{
    public class QuestionStore
    {
        public List<Question> Questions { get; set; }
        public int TotalScore { get; set; }
        public int CurrentScore { get; set; }

    }
}
