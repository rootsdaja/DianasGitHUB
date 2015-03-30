using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirplaneTrafficManagement.Repo
{
    interface IPassengerRepository
    {
        IEnumerable<Passenger> GetPassengers();
        Passenger GetPassengerById(int id);
        void InsertPassenger(Passenger passenger);
        void DeletePassenger(int Id);
        void UpdatePassenger(Passenger passenger);
        void Save();

    }
}
