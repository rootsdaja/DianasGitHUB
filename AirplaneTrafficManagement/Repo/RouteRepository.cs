using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    public class RouteRepository : IRouteRepository
    {
        private AirplaneTrafficEntities _context;

        //public FlightRepository(AirplaneTrafficEntities context)
        //{
        //    this.context = context;
        //}

        public RouteRepository()
        {
            _context = new AirplaneTrafficEntities();
        }

        public IEnumerable<Route> GetRoutes()
        {
            return _context.Route.ToList();
        }

        public Route GetRouteById(int id)
        {
            return _context.Route.Find(id);
        }


        public List<Route> GetRoutesByLeavingLocation(string leaving)
        {
            return _context.Route.Where(l => l.leavingFrom.Equals(leaving)).ToList();
        }

        public List<Route> GetRoutesByGoingToLocation(string going)
        {
            return _context.Route.Where(l => l.goingTo.Equals(going)).ToList();
        }

        public List<Route> GetRoutesByLeavingFromAndGoingToLocation(string leaving, string going)
        {
            return _context.Route.Where(r => r.leavingFrom.Equals(leaving) && r.goingTo.Equals(going)).ToList();
        }

        public List<string> GetAirlineByLeavingAndGoingLocations(string leavingFrom, string goingTo, string name)
        {
            //var routeByLeavingToAndDest = GetRouteByLeavingFromAndGoingToLocation(leavingFrom, goingTo); 

             //ti se returneaza o lista de linii aeriene
            var airlineCompanies = _context.Airline.Where(r => r.companyName.Equals(name)).ToList();
            var leaving =new List<string>();

            if (airlineCompanies != null && airlineCompanies.Count > 0)
            {
                foreach (var airline in airlineCompanies)
                {
                    if (airline != null)
                    {
                        leaving.Add(airline.companyName);
                    }
                }
            } 
            return leaving;
        }
        

        public List<Route> GetRoutesByleavingHour(string hour)
        {
            return _context.Route.Where(a => a.leavingHour.Equals(hour)).ToList();
        }

        public List<Route> GetRoutesByarrivalHour(string hour)
        {
            return _context.Route.Where(a => a.arrivalHour.Equals(hour)).ToList();
        }

        public List<Route> GetRoutesByleavingAndArrivalHour(string hour)
        {
            return _context.Route.Where(a => a.leavingHour.Equals(hour) && a.arrivalHour.Equals(hour)).ToList();
        }

      

        //public List<Airport> SearchAirportByName(string _searchValue)
        //{
        //    return _context.Airports.Where(a => a.airportName.StartsWith(_searchValue)).ToList();
        //}

        //public List<Airport> SearchAirportByNameCountryCityState(string _searchValue)
        //{
        //    return _context.Airports.Where(a => a.airportName.StartsWith(_searchValue) &&
        //        a.city.StartsWith(_searchValue) && a.country.StartsWith(_searchValue)
        //        && a.state.StartsWith(_searchValue)).ToList();
        //}
  
        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

        public void InsertRoute(Route route)
        {
            _context.Route.Add(route);
            _context.SaveChanges();
        }

        public void DeleteRoute(int routeId)
        {
            var route = _context.Route.Find(routeId);
            _context.Route.Remove(route);
            _context.SaveChanges();
        }

        public void UpdateRoute(Route route)
        {
            _context.Entry(route).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void EditRouteRepo(Route route)
        {
            var routeId = _context.Route.FirstOrDefault(f => f.idRoute == route.idRoute);

            routeId.idRoute = route.idRoute;
            routeId.leavingFrom = route.leavingFrom;
            routeId.goingTo = route.goingTo;
            routeId.leavingHour = route.leavingHour;
            routeId.arrivalHour = route.arrivalHour;

            _context.SaveChanges();
        }




        public List<Route> GetRouteByLeavingFromAndGoingToLocation(string leaving, string going)
        {
            throw new NotImplementedException();
        }
    }
}