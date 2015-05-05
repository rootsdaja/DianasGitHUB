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
            return _context.Passenger.ToList();
        }

           public Passenger GetPassengerById(int id)
        {
            return _context.Passenger.Find(id);
        }

  
        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

           public void InsertPassenger(Passenger passenger)
        {
            _context.Passenger.Add(passenger);
            _context.SaveChanges();
        }

           public void DeletePassenger(int Id)
        {
            Passenger passenger = _context.Passenger.Find(Id);
            _context.Passenger.Remove(passenger);
            _context.SaveChanges();
        }

           public void UpdatePassenger(Passenger passenger)
        {
            _context.Entry(passenger).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void EditPassengerRepo(Passenger passenger)
        {
            var passengerId = _context.Passenger.FirstOrDefault(f => f.idPassenger == passenger.idPassenger);

            passengerId.idPassenger = passenger.idPassenger;
            passengerId.adult = passenger.adult;
            passengerId.children = passenger.children;
            passengerId.infants = passenger.infants;

            _context.SaveChanges();
        }

    }
}