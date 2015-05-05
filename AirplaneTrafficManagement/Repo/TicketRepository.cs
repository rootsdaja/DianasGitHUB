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
            return _context.Ticket.ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return _context.Ticket.Find(id);
        }


        public List<Ticket> GetTicketBySeat(string seat)
        {
            return _context.Ticket.Where(t => t.seat.Equals(seat)).ToList();
        }

        public List<Ticket> GetTicketsByClass(string @class)
        {
            return _context.Ticket.Where(t => t.@class.Equals(@class)).ToList();
        }

        public List<Ticket> GetTicketsByRoundtrip(bool roundTrip)
        {
            return _context.Ticket.Where(t => t.roundTrip.Equals(roundTrip)).ToList();
        }

        public List<Ticket> GetTicketsByAvailableTickets(int ticket)
        {
            return _context.Ticket.Where(t => t.availableTickets.Equals(ticket)).ToList();
        }


        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

        public void InsertTicket(Ticket ticket)
        {
            _context.Ticket.Add(ticket);
            _context.SaveChanges();
        }

        public void DeleteTicket(int ticketId)
        {
            Ticket ticket = _context.Ticket.Find(ticketId);
            _context.Ticket.Remove(ticket);
            _context.SaveChanges();
        }

        public void UpdateTicket(Ticket ticket)
        {
            _context.Entry(ticket).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void EditTicketRepo(Ticket ticket)
        {
            var ticketId = _context.Ticket.FirstOrDefault(f => f.idTicket == ticket.idTicket);

            ticketId.idTicket = ticket.idTicket;
            ticketId.seat = ticket.seat;
            ticketId.availableTickets = ticket.availableTickets;
            ticketId.totalTickets = ticket.totalTickets;
            ticketId.@class = ticket.@class;
            ticketId.roundTrip = ticket.roundTrip;

            _context.SaveChanges();
        }
    }
}