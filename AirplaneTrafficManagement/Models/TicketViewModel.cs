using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Models
{
    public class TicketViewModel
    {
        public int idTicket { get; set; }
        public Nullable<int> idAirline { get; set; }
        [DisplayName("Seat Number")]
        public Nullable<int> seat { get; set; }
        [DisplayName("Available Tickets")]
        public Nullable<int> availableTickets { get; set; }
        [DisplayName("Total Tickets")]
        public Nullable<int> totalTickets { get; set; }
        public Nullable<int> idFlight { get; set; }
        [DisplayName("Class")]
        public string @class { get; set; }
        [DisplayName("Round trip")]
        public Nullable<bool> roundTrip { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual Flight Flight { get; set; }
    }
}