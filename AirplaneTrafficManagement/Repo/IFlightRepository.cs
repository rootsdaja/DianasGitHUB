using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTrafficManagement.Repo
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> GetFlights();
        Flight GetFlightById(int flightId);
        List<Flight> GetFlightByDeparture(string departure);
        List<Flight> GetFlightByDepartureAndArrivalLocation(string depart, string arrive);
        List<Flight> SearchFlightByDepartureAndArrival(string _searchValue);
        void InsertFlight(Flight flight);
        void EditFlightRepo(Flight flight);
        void DeleteFlight(int flightId);
        void UpdateFlightRepo(Flight flight);
        void Save();
    }
}