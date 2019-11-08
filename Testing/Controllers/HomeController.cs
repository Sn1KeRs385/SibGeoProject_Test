using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;
using Newtonsoft.Json;
using System.Text;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext db;

        public HomeController(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoadSurvey()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoadSurveyWithFIO(string inputFullName)
        {
            VM_LoadSurveyWithFIO ViewModel = new VM_LoadSurveyWithFIO();

            IEnumerable<Questions> Questions = db.Questions.ToArray();
            foreach (Questions Question in Questions)
            {
                IEnumerable<Answers> Answers = db.Answers.Where(element => element.QuestionsID == Question.ID).ToArray();
            }

            ViewModel.Questions = Questions;
            ViewModel.UserName = inputFullName;

            return View(ViewModel);
        }
        [HttpPost]
        public void SaveSurvey(string Answers)
        {
            List<SurveyResult> Results = JsonConvert.DeserializeObject<List<SurveyResult>>(Answers);
            foreach (SurveyResult Result in Results)
            {
                db.SurveyResult.Add(Result);
            }
            db.SaveChanges();
        }
        public ActionResult GetStatistics()
        {
            VM_GetStatistics ViewModel = new VM_GetStatistics();
            ViewModel.ResultTableRecord = new List<VM_GetStatistics_ResultTableRecord>();

            IEnumerable<Questions> Questions = db.Questions.ToArray();
            foreach (Questions Question in Questions)
            {
                Answers TrueAnswer = db.Answers.Where(element => element.QuestionsID == Question.ID).Where(element => element.AnswerTrue == true).FirstOrDefault();
                IEnumerable<SurveyResult> SurveyResultTrue = db.SurveyResult.Where(element => element.QuestionID == Question.ID).Where(element => element.AnswerID == TrueAnswer.ID).ToArray();
                IEnumerable<SurveyResult> SurveyResultFalse = db.SurveyResult.Where(element => element.QuestionID == Question.ID).Where(element => element.AnswerID != TrueAnswer.ID).ToArray();

                VM_GetStatistics_ResultTableRecord Temp = new VM_GetStatistics_ResultTableRecord();
                Temp.QuestionID = Question.ID;
                Temp.AnswersTrue = SurveyResultTrue.Count();
                Temp.AnswersFalse = SurveyResultFalse.Count();
                Temp.AnswersAll = SurveyResultTrue.Count() + SurveyResultFalse.Count();
                Temp.Question = Question.Question;

                ViewModel.ResultTableRecord.Add(Temp);
            }

            return View(ViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
