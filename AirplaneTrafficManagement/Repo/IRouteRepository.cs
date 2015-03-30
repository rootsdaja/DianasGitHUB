using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirplaneTrafficManagement.Repo
{
    public interface IRouteRepository
    {
        IEnumerable<Route> GetRoutes();
        Route GetRouteById(int id);
        List<Route> GetRoutesByLeavingLocation(string leaving);
        List<Route> GetRoutesByGoingToLocation(string going);
        List<Route> GetRouteByLeavingFromAndGoingToLocation(string leaving, string going);
        List<string> GetAirlineByLeavingAndGoingLocations(string leavingFrom, string goingTo, string name);
        List<Route> GetRoutesByleavingHour(string hour);
        List<Route> GetRoutesByarrivalHour(string hour);
        List<Route> GetRoutesByleavingAndArrivalHour(string hour);
        void InsertRoute(Route route);
        void DeleteRoute(int routeId);
        void UpdateRoute(Route route);
        void Save();
        void EditRouteRepo(Route route);
    }
}
