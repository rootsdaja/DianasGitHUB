using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirplaneTrafficManagement.Models
{
    public class FlightViewModel
    {
       
        public int idFlight { get; set; }

        [DisplayName("Departure From")]
        public string departureFrom { get; set; }

        [DisplayName("Arrive At")]
        public string arriveAt { get; set; }

        [DisplayName("Depart On")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> departOn { get; set; }

        [DisplayName("Return On")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> returnOn { get; set; }

        [DisplayName("Depart Hour")]
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> time { get; set; }

        public Nullable<int> idAirport { get; set; }
        public Nullable<int> idRoute { get; set; }

        public virtual Airport Airport { get; set; }
        public virtual Route Route { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public List<FlightViewModel> _flightList { get; set; }
        public List<SelectListItem> FlightList { get; set; }

        //[Display(Name = "Search")]
        //public string _searchValue { get; set; }
        
    }
}