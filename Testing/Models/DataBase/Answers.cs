using System.ComponentModel.DataAnnotations.Schema;

namespace Testing.Models
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