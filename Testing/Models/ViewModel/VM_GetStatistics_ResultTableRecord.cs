using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testing.Models
{
    public class VM_GetStatistics_ResultTableRecord
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public int AnswersAll { get; set; }
        public int AnswersTrue { get; set; }
        public int AnswersFalse { get; set; }
    }
}