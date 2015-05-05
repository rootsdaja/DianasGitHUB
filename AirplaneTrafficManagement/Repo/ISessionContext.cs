using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    interface ISessionContext
    {
            HttpContext _httpContext { get; set; }
            string UserFirstName { get; set; }
            int UserIdentifier { get; set; }
            bool UserType { get; set; }
            bool Admin { get; set; }
            bool RegularUser { get; set; }
    }
}
