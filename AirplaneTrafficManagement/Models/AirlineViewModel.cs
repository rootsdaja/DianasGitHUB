using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace AirplaneTrafficManagement.Models
{
    public class AirlineViewModel
    {

        public int idAirline { get; set; }

        [DisplayName("Airline Company Name")]
        public string companyName { get; set; }
        public byte[] logo { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public List<AirlineViewModel> _airlineList { get; set; }
        public List<SelectListItem> AirlineList { get; set; }
    }
}