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
        List<Flight> GetFlightByDeparture(int departure);
        List<Flight> GetFlightByDepartureAndArrivalLocation(int depart, int arrive);
        IEnumerable<Flight> GetFlightByDepartureAndArrivalHour(DateTime arrivalHour, DateTime departureHour);
        //List<Flight> SearchFlightByDepartureAndArrival(int _searchValue);
        void InsertFlight(Flight flight);
        void EditFlightRepo(Flight flight);
        void DeleteFlight(int flightId);
        void UpdateFlightRepo(Flight flight);
        void Save();
    }
}