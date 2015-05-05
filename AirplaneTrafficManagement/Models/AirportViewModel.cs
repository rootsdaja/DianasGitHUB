using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Models
{
    public class AirportViewModel
    {
        public int idAirport { get; set; }

        [DisplayName("Airport Name")]
        public string airportName { get; set; }
        [DisplayName("City")]
        public string city { get; set; }
        [DisplayName("Country")]
        public string country { get; set; }
        [DisplayName("State")]
        public string state { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Route> Routes { get; set; }

        public IEnumerable<Airport> AirportList { get; set; }
        
    }
}