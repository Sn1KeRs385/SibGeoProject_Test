using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
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