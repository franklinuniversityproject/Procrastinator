using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Procrastinator.Models
{
    public class CourseData
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CourseCode { get; set; }
        public int SubjectTypeId { get; set; }
        public int CreditHours { get; set; }
        public int DifficultyRating { get; set; }

        public virtual SubjectType SubjectType { get; set; }
    }
}