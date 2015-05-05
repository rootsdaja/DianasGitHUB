using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirplaneTrafficManagement.Repo
{
    public class FlightRepository : IFlightRepository
    {
        private AirplaneTrafficEntities _context;

        public FlightRepository()
        {
            _context = new AirplaneTrafficEntities();
        }

        public IEnumerable<Flight> GetFlights()
        {
            return _context.Flight.ToList();
        }

        public Flight GetFlightById(int id)
        {
            return _context.Flight.Find(id);
        }

        public List<Flight> GetFlightByDeparture(int departure)
        {
            var flight = _context.Flight.Where(f => f.departureFrom == departure).ToList();
            return flight;
        }

        public List<Flight> GetFlightByDepartureAndArrivalLocation(int depart, int arrive)
        {
            var flight = _context.Flight.Where(f => f.departureFrom == depart && f.arriveAt == arrive).ToList();
            return flight;
        }

        public IEnumerable<Flight> GetFlightByDepartureAndArrivalHour(DateTime arrivalHour, DateTime departureHour)
        {
            var flight = _context.Flight.Where(f => f.departOn.Equals(departureHour) && f.returnOn.Equals(arrivalHour));
            return flight;
        }

        //public List<Flight> GetCityByCountry(string city, string country)
        //{
        //    var cityByCountry = _context.Flights.Where(c => c.Airport.city == city && c.Airport.country == country).ToList();
        //    return cityByCountry;
        //}

        //public List<Flight> SearchFlightByDepartureAndArrival(int _searchValue)
        //{
        //    var flight = _context.Flights.Where(f => f.departureFrom.StartsWith(_searchValue) && f.arriveAt.StartsWith(_searchValue)).ToList();
        //    return flight;
        //}
  
        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

        public void InsertFlight(Flight flight)
        {
            _context.Flight.Add(flight);
            _context.SaveChanges();
        }

        public void DeleteFlight(int flightId)
        {
            var flight = _context.Flight.Find(flightId);

            _context.Flight.Remove(flight);
            _context.SaveChanges();
        }

        public void UpdateFlightRepo(Flight flight)
        {
            _context.Entry(flight).State = EntityState.Modified;
        }

        public void EditFlightRepo(Flight flight)
        {
            var flightId = _context.Flight.FirstOrDefault(f => f.idFlight == flight.idFlight);

            flightId.departOn = flight.departOn;
            flightId.returnOn = flight.returnOn;
            flightId.departureFrom = flight.departureFrom;
            flightId.arriveAt = flight.arriveAt;

            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}