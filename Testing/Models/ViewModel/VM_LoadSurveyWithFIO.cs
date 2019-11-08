using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testing.Models
{
    public class VM_LoadSurveyWithFIO
    {
        public string UserName { get; set; }
        public IEnumerable<Questions> Questions { get; set; }

        //нужнs что бы выводить номер вопроса (просто порядковый номер а не id вопроса)
        private int QuestionCounter = 0;
        public int GetCounter()
        {
            return ++QuestionCounter;
        }
    }
}