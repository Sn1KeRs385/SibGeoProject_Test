using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testing.Models
{
    [Table("Questions")]
    public class Questions
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public ICollection<Answers> Answers { get; set; }
        public Questions()
        {
            Answers = new List<Answers>();
        }
    }
}