using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Procrastinator.Models;

namespace Procrastinator.Controllers
{
    public class CoursesController : Controller
    {
        private Summer2019 db = new Summer2019();

        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.SubjectType);
            return View(courses.ToList());
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
                courses = db.Courses.ToList();

            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var test = serializer.Serialize(courses);
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

    }
}
