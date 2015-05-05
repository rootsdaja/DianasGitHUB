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

        [Display(Name = "Departure From")]
        public int DepartureFromId { get; set; }

        [Display(Name = "Arrive At")]
        public int ArrivalAtId { get; set; }

        [DisplayName("Depart On")]
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> departOn { get; set; }

        [DisplayName("Return On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> returnOn { get; set; }

        public Nullable<int> idAirport { get; set; }
        public Nullable<int> idRoute { get; set; }

        public virtual Airport DepartureFromAirport { get; set; }
        public virtual Airport ArrivalAtAirport { get; set; }
        public virtual Route Route { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}