using System;
using System.Linq;
using System.Web;
using Procrastinator.Models;

namespace Procrastinator.Shared
{
    public class CourseBO
    {
        private Summer2019 db = new Summer2019();

        public static Func<Course, CourseData> MapCourseToCourseData = m =>
        {
            return new CourseData()
            {
                Id = m.Id,
                Description = m.Description,
                CourseCode = m.CourseCode,
                SubjectTypeId = m.SubjectTypeId,
                CreditHours = m.CreditHours,
                DifficultyRating = m.DifficultyRating
            };
        };

        public CourseData GetCourseDataById(int courseID)
        {
            return db.Courses
                .Where(m => m.Id == courseID)
                .Select(MapCourseToCourseData)
                .First();
        }

        public int GetDifficultyByCourseID(int courseID)
        {
            return db.Courses
                .Where(m => m.Id == courseID)
                .Select(x => x.DifficultyRating)
                .First();
        }
    }
}