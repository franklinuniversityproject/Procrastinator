using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Procrastinator.Models
{
    public class EventSelectionViewModel
    {

        private Summer2019 db = new Summer2019();

        //public List<Event> EventTypes { get; set; }

        public EventSelectionViewModel()
        {
            //EventTypes = db.EventTypes.ToList();
        }
    }
}