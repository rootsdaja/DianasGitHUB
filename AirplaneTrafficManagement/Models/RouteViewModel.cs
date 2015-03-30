using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Models
{
    public class RouteViewModel
    {
        public int idRoute { get; set; }
        [DisplayName("Leaving From")]
        public string leavingFrom { get; set; }
        [DisplayName("Going To")]
        public string goingTo { get; set; }
        [DisplayName("Leaving Hour")]
        public Nullable<System.TimeSpan> leavingHour { get; set; }
        [DisplayName("Going Hour")]
        public Nullable<System.TimeSpan> arrivalHour { get; set; }
        public Nullable<int> idAirport { get; set; }

        public virtual Airport Airport { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public List<RouteViewModel> _routeList { get; set; }
    }
}