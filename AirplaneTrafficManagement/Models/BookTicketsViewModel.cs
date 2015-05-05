using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace AirplaneTrafficManagement.Models
{
    public class BookTicketsViewModel
    {
        public int idTicket { get; set; }

        [DisplayName("Seat Number")]
        public Nullable<int> Seat { get; set; }

        [DisplayName("Class")]
        public string Class { get; set; }

        [DisplayName("Round trip")]
        public bool RoundTrip { get; set; }

        [Display(Name = "Departure From")]
        public int DepartureFromId { get; set; }

        [Display(Name = "Arrive At")]
        public int ArrivalAtId { get; set; }

        public virtual Airport DepartureFromAirport { get; set; }
        public virtual Airport ArrivalAtAirport { get; set; }

        [DisplayName("Depart On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DepartOn { get; set; }

        [DisplayName("Return On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReturnOn { get; set; }

        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public TimeSpan LeavingHour { get; set; }
        public TimeSpan ArrivalHour { get; set; }

        [Display(Name="Airline")]
        public int AirlineId { get; set; }
        public int ClassId { get; set; }

        public int Adult { get; set; }
        public int Children { get; set; }
        public int Infant { get; set; }

    }
}