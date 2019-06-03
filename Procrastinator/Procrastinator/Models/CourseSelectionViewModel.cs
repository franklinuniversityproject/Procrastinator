using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Procrastinator.Models
{
    public class CourseSelectionViewModel
    {
        private Summer2019 db = new Summer2019();


        public List<Course> Courses { get; set; }
        public List<SubjectType> SubjectTypes { get; set; }

        public CourseSelectionViewModel()
        {
            Courses = db.Courses.ToList();
            SubjectTypes = db.SubjectTypes.ToList();
        }
    }
}