using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadSurvey()
        {
            return View();
        }
        public ActionResult GetStatistics()
        {
            List<ResultTable> ResultTable = new List<ResultTable>();
            ApplicationContext db = new ApplicationContext();
            IEnumerable<Questions> Questions = db.Questions.ToArray();
            foreach (Questions Question in Questions)
            {
                Answers TrueAnswer = db.Answers.Where(element => element.QuestionsID == Question.ID).Where(element => element.AnswerTrue == true).FirstOrDefault();
                IEnumerable<SurveyResult> SurveyResultTrue = db.SurveyResult.Where(element => element.QuestionID == Question.ID).Where(element => element.AnswerID == TrueAnswer.ID).ToArray();
                IEnumerable<SurveyResult> SurveyResultFalse = db.SurveyResult.Where(element => element.QuestionID == Question.ID).Where(element => element.AnswerID != TrueAnswer.ID).ToArray();

                ResultTable Temp = new ResultTable();
                Temp.QuestionID = Question.ID;
                Temp.AnswersTrue = SurveyResultTrue.Count();
                Temp.AnswersFalse = SurveyResultFalse.Count();
                Temp.AnswersAll = SurveyResultTrue.Count() + SurveyResultFalse.Count();
                Temp.Question = Question.Question;

                ResultTable.Add(Temp);
            }
            ViewBag.ResultTable = ResultTable;
            return View();
        }
        [HttpPost]
        public ActionResult LoadSurveyWithFIO(string inputFullName)
        {
            ApplicationContext db = new ApplicationContext();
            IEnumerable<Questions> Questions = db.Questions.ToArray();
            foreach (Questions Question in Questions) {
                IEnumerable<Answers> Answers = db.Answers.Where(element => element.QuestionsID == Question.ID).ToArray();
            }
            
            ViewBag.Questions = Questions;
            ViewBag.User = inputFullName;
            return View();
        }
        [HttpPost]
        public void SaveSurvey(string Answers)
        {
            List<SurveyResult> Results = JsonConvert.DeserializeObject<List<SurveyResult>>(Answers);
            ApplicationContext db = new ApplicationContext();
            foreach (SurveyResult Result in Results)
            {
                db.SurveyResult.Add(Result);
            }
            db.SaveChanges();
        }
    }
}