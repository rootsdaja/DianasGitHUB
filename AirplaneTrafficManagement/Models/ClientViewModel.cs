using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Models
{
    public class ClientViewModel
    {     
        [Required]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [DisplayName("Username")]
        public string username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Phone")]
        public int phone { get; set; }

        [DisplayName("Address")]
        public string address {get;set;}

        [DisplayName("City")]
        public string city { get; set; }

        [DisplayName("UserType")]
        public string userType {get;set;}

        public virtual Passenger Passenger { get; set; }
        public virtual Ticket Ticket { get; set; }

        public int idClient { get; set; }
        public List<ClientViewModel> _clientList { get; set; }

    }
}