using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirplaneTrafficManagement.Repo
{
    interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets();
        Ticket GetTicketById(int id);
        List<Ticket> GetTicketBySeat(string seat);
        List<Ticket> GetTicketsByClass(string @class);
        List<Ticket> GetTicketsByRoundtrip(bool roundTrip);
        List<Ticket> GetTicketsByAvailableTickets(int ticket);
        void InsertTicket(Ticket ticket);
        void DeleteTicket(int ticketId);
        void UpdateTicket(Ticket ticket);
        void Save();
    }
}
