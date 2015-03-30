using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    public class AirlineRepository : IAirlineRepository
    {
          private AirplaneTrafficEntities _context;

        //public FlightRepository(AirplaneTrafficEntities context)
        //{
        //    this.context = context;
        //}

        public AirlineRepository()
        {
            _context = new AirplaneTrafficEntities();
        }

        public IEnumerable<Airline> GetAirlines()
        {
            return _context.Airlines.ToList();
        }

        public Airline GetAirlineById(int id)
        {
            return _context.Airlines.Find(id);
        }

        public List<Airline> GetAirlineByCompanyName(string name)
        {
            var airline = _context.Airlines.Where(a => a.companyName == name).ToList();
            return airline;
        }

        public List<Airline> SearchAirlineByCompanyName(string _searchValue)
        {
            var airline = _context.Airlines.Where(a => a.companyName.StartsWith(_searchValue)).ToList();
            return airline;
        }
  
        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

        public void InsertAirline(Airline airline)
        {
            _context.Airlines.Add(airline);
            _context.SaveChanges();
        }

        public void DeleteAirline(int airlineId)
        {
            var airline = _context.Airlines.Find(airlineId);
            _context.Airlines.Remove(airline);
            _context.SaveChanges();
        }

        public void EditAirlinetRepo(Airline airline)
        {
            var airlineId = _context.Airlines.FirstOrDefault(f => f.idAirline == airline.idAirline);

            airlineId.idAirline = airline.idAirline;
            airlineId.companyName = airline.companyName;
            airlineId.logo = airline.logo;

            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }




        public void UpdateAirline(Airline airline)
        {
            throw new NotImplementedException();
        }
    }
}