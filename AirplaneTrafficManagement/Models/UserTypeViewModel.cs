using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Models
{
    public class UserTypeViewModel
    {
        public int idUserType { get; set; }
        [DisplayName("Admin")]
        public string admin { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}