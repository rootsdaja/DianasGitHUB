using AirplaneTrafficManagement.Repo;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AirplaneTrafficManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

             var container = new ServiceContainer();
            container.RegisterControllers();        
            
            //mine
            container.Register<IFlightRepository, FlightRepository>();
            container.Register<IAirlineRepository, AirlineRepository>();
            container.Register<IAirportRepository, AirportRepository>();
            container.Register<IClientRepository, ClientRepository>();
            container.Register<IPassengerRepository, PassengerRepository>();
            container.Register<IRouteRepository, RouteRepository>();
            container.Register<ITicketRepository, TicketRepository>();
            container.Register<IUserTypeRepository, UserTypeRepository>();

            container.EnableMvc();
        }
    }
}
