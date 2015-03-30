using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    public class AirportRepository : IAirportRepository
    {
        private AirplaneTrafficEntities _context;

        //public FlightRepository(AirplaneTrafficEntities context)
        //{
        //    this.context = context;
        //}

        public AirportRepository()
        {
            _context = new AirplaneTrafficEntities();
        }

        public IEnumerable<Airport> GetAirports()
        {
            return _context.Airports.ToList();
        }

        public Airport GetAirportById(int id)
        {
            return _context.Airports.Find(id);
        }


        public List<Airport> GetAirportsByName(string name)
        {
            return _context.Airports.Where(a => a.airportName.Equals(name)).ToList();
        }

        public List<Airport> GetAirportsByCity(string city)
        {
            return _context.Airports.Where(a => a.city.Equals(city)).ToList();
        }

        public List<Airport> GetAiportsByCountry(string country)
        {
            return _context.Airports.Where(a => a.country == country).ToList();
        }

        public List<Airport> GetAirportByState(string state)
        {
            return _context.Airports.Where(a => a.state.Equals(state)).ToList();
        }

     
        public List<string> GetCityByCountry(string country)
        {
            // - returneaza lista de aeropoarte dintr-un oras
            //var airports = _context.Airports.Where(c => c.country.Equals(country)).ToList();
            var airportList = GetAiportsByCountry(country);
            //introducem o lista de orase
            var cities = new List<string>();
            //pentru fiecare aeroport returneaza un oras
            if (airportList != null && airportList.Count > 0)
            {
                foreach (var airport in airportList)
                {
                    if (airport != null)
                    {
                        //pentru fiecare aeroport returnat din lista de aeropoarte
                        //adauga-mi in lista de mai sus "cities", orasul 
                        cities.Add(airport.city);
                    }
                }
            }
            return cities;
        }

        public List<Airport> SearchAirportByName(string _searchValue)
        {
            return _context.Airports.Where(a => a.airportName.StartsWith(_searchValue)).ToList();
        }

        public List<Airport> SearchAirportByNameCountryCityState(string _searchValue)
        {
            return _context.Airports.Where(a => a.airportName.StartsWith(_searchValue) &&
                a.city.StartsWith(_searchValue) && a.country.StartsWith(_searchValue)
                && a.state.StartsWith(_searchValue)).ToList();
        }
  
        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

        public void InsertAirport(Airport airport)
        {
            _context.Airports.Add(airport);
            _context.SaveChanges();
        }

        public void DeleteAirport(int airportId)
        {
            var airport = _context.Airports.Find(airportId);
            _context.Airports.Remove(airport);
            _context.SaveChanges();
        }

        public void UpdateAirport(Airport airport)
        {
            _context.Entry(airport).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void EditAirportRepo(Airport airport)
        {
            var airportId = _context.Airports.FirstOrDefault(f => f.idAirport == airport.idAirport);

            airportId.idAirport = airport.idAirport;
            airportId.airportName = airport.airportName;
            airportId.city = airport.city;
            airportId.country = airport.country;
            airportId.state = airport.state;

            _context.SaveChanges();
        }
    }
}