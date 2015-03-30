using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Models
{
    public class ClientViewModel
    {     
        public int idClient { get; set; }
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [DisplayName("Username")]
        public string username { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Phone")]
        public Nullable<int> phone { get; set; }
        [DisplayName("City")]
        public string city { get; set; }
        public Nullable<int> idUserType { get; set; }
        public Nullable<int> idPassenger { get; set; }
        public Nullable<int> idTicket { get; set; }

        public virtual Passenger Passenger { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual UserType UserType { get; set; }

        public List<ClientViewModel> _clientList { get; set; }

    }
}