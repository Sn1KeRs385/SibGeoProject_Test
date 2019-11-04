using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class ResultTable
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public int AnswersAll { get; set; }
        public int AnswersTrue { get; set; }
        public int AnswersFalse { get; set; }

    }
}