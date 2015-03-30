using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTrafficManagement.Repo
{
    public interface IAirportRepository
    {
        IEnumerable<Airport> GetAirports();
        Airport GetAirportById(int id);
        List<Airport> GetAirportsByName(string name);
        List<Airport> GetAirportsByCity(string city);
        List<Airport> GetAiportsByCountry(string country);
        List<Airport> GetAirportByState(string state);
        List<string> GetCityByCountry(string country);
        List<Airport> SearchAirportByName(string _searchValue);
        List<Airport> SearchAirportByNameCountryCityState(string _searchValue);
        void InsertAirport(Airport airport);
        void DeleteAirport(int airportId);
        void UpdateAirport(Airport airport);
        void Save();
        void EditAirportRepo(Airport airport);

    }
}
