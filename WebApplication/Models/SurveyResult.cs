using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
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