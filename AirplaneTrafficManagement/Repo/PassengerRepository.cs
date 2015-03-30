using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    public class PassengerRepository : IPassengerRepository
    {
              private AirplaneTrafficEntities _context;

        //public FlightRepository(AirplaneTrafficEntities context)
        //{
        //    this.context = context;
        //}

              public PassengerRepository()
        {
            _context = new AirplaneTrafficEntities();
        }

           public IEnumerable<Passenger> GetPassengers()
        {
            return _context.Passengers.ToList();
        }

           public Passenger GetPassengerById(int id)
        {
            return _context.Passengers.Find(id);
        }

  
        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

           public void InsertPassenger(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
        }

           public void DeletePassenger(int Id)
        {
            Passenger passenger = _context.Passengers.Find(Id);
            _context.Passengers.Remove(passenger);
        }

           public void UpdatePassenger(Passenger passenger)
        {
            _context.Entry(passenger).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}