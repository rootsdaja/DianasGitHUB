using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Models
{
    public class PassengerViewModel
    {
        public int idPassenger { get; set; }
           [DisplayName("Adult")]
        public Nullable<int> adult { get; set; }
           [DisplayName("Children")]
        public Nullable<int> children { get; set; }
           [DisplayName("Infants")]
        public Nullable<int> infants { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        
    }
}