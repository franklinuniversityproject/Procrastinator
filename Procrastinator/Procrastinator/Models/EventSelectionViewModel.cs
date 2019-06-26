using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Procrastinator.Models
{
    public class EventSelectionViewModel
    {
        private Summer2019 db = new Summer2019();

        public List<Event> DefaultEvents { get; set; }
        public List<EventType> EventTypes { get; set; }
        public List<Event> UserEventList { get; set; }
        public int SelectedEventType { get; set; }

        public EventSelectionViewModel(CourseSelectionViewModel model)
        {
            CreateDefaults(model);

            EventTypes = db.EventTypes.ToList();
        }

        public class Event
        {
            private Summer2019 db = new Summer2019();

            public int EventTypeId { get; set; }
            public string EventDescription { get; set; }
            public int? Hours { get; set; }
            public int? Mins { get; set; }
            public bool[] Weekdays { get; set; }

            public Event()
            {
                Weekdays = new bool[7];
            }
        }

        public void CreateDefaults(CourseSelectionViewModel model)
        {
            DefaultEvents = new List<Event>();

            var sleep = new Event()
            {
                EventTypeId = 2,
                EventDescription = db.EventTypes.Where(x => x.Id == 2).FirstOrDefault().Description,
                Hours = 8
            };
            sleep.Weekdays = Array.ConvertAll(sleep.Weekdays, i => true);

            DefaultEvents.Add(sleep);

            if (model.SelectedCourses != null)
            {
                var courseId = model.SelectedCourses.Where(c => c != 0);
                var courses = db.Courses.Where(c => courseId.Contains(c.Id)).ToList();
                var totalCourseTime = courses.Select(c => c.CreditHours).ToList().Sum() * 60;
                var dayCounter = 0;

                foreach (var course in courses)
                {
                    if (dayCounter >= 7) dayCounter = 0;
                    var evt = new Event
                    {
                        EventTypeId = 3,
                        EventDescription = db.EventTypes.Where(x => x.Id == 3).FirstOrDefault().Description + ": " + course.Description,
                        Hours = course.CreditHours
                    };
                    evt.Weekdays[dayCounter] = true;
                    DefaultEvents.Add(evt);
                    dayCounter++;
                }
            }

        }

    }
}