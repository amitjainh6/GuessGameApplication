using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GuessGameApplication.BLL;

namespace GuessGameApplication.Controllers
{
    public class HomeController : Controller
    {
        private QuestionLogic _questionLogic;

        public HomeController()
        {
            _questionLogic = new QuestionLogic();
        }

        public ActionResult Index()
        {
            var model = _questionLogic.GetAnimals();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Add and Delete Animals from the list";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetQuestion(string id, string boolString)
        {
            return Json(_questionLogic.GetNextQuestion(id, boolString), JsonRequestBehavior.AllowGet);
        }
    }
}