using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    [Table("Answers")]
    public class Answers
    {
        public int ID { get; set; }
        public int QuestionsID { get; set; }
        public string AnswerText { get; set; }
        public bool AnswerTrue { get; set; }
    }
}