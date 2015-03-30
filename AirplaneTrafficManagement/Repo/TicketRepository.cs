using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    public class TicketRepository : ITicketRepository
    {
          private AirplaneTrafficEntities _context;

        //public FlightRepository(AirplaneTrafficEntities context)
        //{
        //    this.context = context;
        //}

        public TicketRepository()
        {
            _context = new AirplaneTrafficEntities();
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _context.Tickets.ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return _context.Tickets.Find(id);
        }


        public List<Ticket> GetTicketBySeat(string seat)
        {
            return _context.Tickets.Where(t => t.seat.Equals(seat)).ToList();
        }

        public List<Ticket> GetTicketsByClass(string @class)
        {
            return _context.Tickets.Where(t => t.@class.Equals(@class)).ToList();
        }

        public List<Ticket> GetTicketsByRoundtrip(bool roundTrip)
        {
            return _context.Tickets.Where(t => t.roundTrip.Equals(roundTrip)).ToList();
        }

        public List<Ticket> GetTicketsByAvailableTickets(int ticket)
        {
            return _context.Tickets.Where(t => t.availableTickets.Equals(ticket)).ToList();
        }


        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

        public void InsertTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
        }

        public void DeleteTicket(int ticketId)
        {
            Ticket ticket = _context.Tickets.Find(ticketId);
            _context.Tickets.Remove(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            _context.Entry(ticket).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}