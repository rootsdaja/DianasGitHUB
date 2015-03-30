using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTrafficManagement.Repo
{
        public interface IAirlineRepository
    {
        IEnumerable<Airline> GetAirlines();
        Airline GetAirlineById(int id);
        List<Airline> GetAirlineByCompanyName(string name);
        List<Airline> SearchAirlineByCompanyName(string _searchValue);
        void InsertAirline(Airline airline);
        void DeleteAirline(int airlineId);
        void EditAirlinetRepo(Airline airline);
        void UpdateAirline(Airline airline);
        void Save();
    }
}
