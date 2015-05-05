using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    public class WebSessionContext
    {
         public WebSessionContext() { }

        public bool verificare;

        private HttpContext  _httpContext;
        private HttpContext HttpContext
        {
            get
            {
                if (_httpContext == null && HttpContext.Current != null)
                    _httpContext = HttpContext.Current;
                return _httpContext;
            }
            set
            {
                _httpContext = value;
            }
        }

        public string UserFirstName
        {

            get
            {
                if (_httpContext.Session["username"] != null)
                {
                    //Retrieving UserName from Session

                }
                return (string)HttpContext.Session["username"];
            }
            set
            {
                HttpContext.Session["username"] = value;
            }


        }

        public int UserIdentifier
        {

            get
            {
                return (int)HttpContext.Session["idClient"];
            }
            set
            {
                HttpContext.Session["idClient"] = value;
            }
        }



        public bool VerifyIfLogged
        {
             get
            {
                
                return (bool)(HttpContext.Session["VerifyIfLogged"] ?? false);
            }
            set
            {
                HttpContext.Session["VerifyIfLogged"] = value;
            }
        }

       

        public bool UserType
        {
            get
            {
                return (bool)(HttpContext.Session["UserType"] ?? false);
            }
            set
            {
                HttpContext.Session["UserType"] = value;
            }
        }

        public bool Admin
        {
            get
            {
                return (bool)(HttpContext.Session["Admin"] ?? false);
            }
            set
            {
                HttpContext.Session["Admin"] = value;
            }
        }

        public bool RegularUser
        {
            get
            {
                return (bool)(HttpContext.Session["RegularUser"] ?? false);
            }
            set
            {
                HttpContext.Session["RegularUser"] = value;
            }
        }

        public bool isLogged { get; set; }
    
    
    }
}