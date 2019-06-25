using Procrastinator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Procrastinator.Controllers
{
    public class HomeController : Controller
    {
        private Summer2019 db = new Summer2019();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Courses()
        {
            var model = new Models.CourseSelectionViewModel();
            return View(model);
        }

        [HttpPost]
        public JsonResult GetCourses(int? subjectTypeId)
        {
            var courses = new List<Course>();

            db.Configuration.ProxyCreationEnabled = false;
            if (subjectTypeId.HasValue)
            {
                courses = db.Courses.Where(x => x.SubjectTypeId == subjectTypeId).ToList();
            }
            else
            {
                courses = db.Courses.ToList();
            }

            return Json(courses, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Lookup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Events()
        {
            return View();
        }
    }
}