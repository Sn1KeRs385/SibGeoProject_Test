using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testing.Models
{
    [Table("SurveyResult")]
    public class SurveyResult
    {
        public int ID { get; set; }
        public string User { get; set; }
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }
    }
}