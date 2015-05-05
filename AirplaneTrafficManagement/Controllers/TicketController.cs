using AirplaneTrafficManagement.Database;
using AirplaneTrafficManagement.Models;
using AirplaneTrafficManagement.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AirplaneTrafficManagement.Controllers
{
    public class TicketController : Controller
    {
        ITicketRepository _ticketRepo;
        IAirportRepository _airportRepo;
        IPassengerRepository _passengerRepo;
        IAirlineRepository _airlineRepo;
        IFlightRepository _flightRepo;

        public TicketController(ITicketRepository repo, IAirlineRepository airlineRepo,
            IAirportRepository airportRepo, IPassengerRepository passRepo, IFlightRepository flightRepo)
        {
            _ticketRepo = repo;
            _airlineRepo = airlineRepo;
            _passengerRepo = passRepo;
            _airportRepo = airportRepo;
            _flightRepo = flightRepo;
        }

           // GET: Ticket
        public ActionResult Index()
        {
            var ticketList = _ticketRepo.GetTickets();
            return View(ticketList);
        }


        public ActionResult Create()
        {
            var airportList = _airportRepo.GetAirports();
            var airlineList = _airlineRepo.GetAirlines();
            var ticketList = _ticketRepo.GetTickets();

            var flight = new Flight();
            var airline = new Airline();
            var ticket = new Ticket();

            ViewBag.DepartureFromId = new SelectList(airportList, "idAirport", "airportName", flight.departureFrom);
            ViewBag.ArrivalAtId = new SelectList(airportList, "idAirport", "airportName", flight.arriveAt);
            ViewBag.AirlineId = new SelectList(airlineList, "idAirline", "companyName", airline.idAirline);
            ViewBag.Class = new SelectList(ticketList, "idTicket", "Class", ticket.idTicket);

            return View("AddBookFlight", new BookTicketsViewModel());
        }

        public ActionResult Add(BookTicketsViewModel model)
        {
            var vmTicket = new Ticket();

            var flight = new Flight();
            var airline = new Airline();
            var passenger = new Passenger();
            var ticket = new Ticket();
            var airportDepature = new Airport();

            var airportList = _airportRepo.GetAirports();
            var airlineList = _airlineRepo.GetAirlines();
            var ticketList = _ticketRepo.GetTickets();

            ViewBag.DepartureFromId = new SelectList(airportList, "idAirport", "airportName", flight.departureFrom);
            ViewBag.ArrivalAtId = new SelectList(airportList, "idAirport", "airportName", flight.arriveAt);
            ViewBag.AirlineId = new SelectList(airlineList, "idAirline", "companyName", airline.idAirline);
            ViewBag.Class = new SelectList(ticketList, "idTicket", "Class", ticket.idTicket);

            flight.departureFrom = model.DepartureFromId;
            flight.arriveAt = model.ArrivalAtId;
            flight.departOn = model.DepartOn;
            flight.returnOn = model.ReturnOn;

            ticket.idTicket = model.idTicket;
            ticket.roundTrip = model.RoundTrip;
            ticket.seat = model.Seat;
            ticket.@class = model.Class;
            ticket.price = model.Price;

            passenger.adult = model.Adult;
            passenger.children = model.Children;
            passenger.infants = model.Infant;

            airline.idAirline = model.AirlineId;

            _flightRepo.InsertFlight(flight);
            _ticketRepo.InsertTicket(ticket);
            _passengerRepo.InsertPassenger(passenger);
            _airlineRepo.InsertAirline(airline);

            vmTicket.Flight = flight;
            vmTicket.roundTrip = ticket.roundTrip;
            vmTicket.seat = ticket.seat;

            vmTicket.@class = _ticketRepo.GetTicketById(Convert.ToInt32(ticket.@class)).@class;
            vmTicket.Passenger = passenger;
            vmTicket.Airline = airline;

            return RedirectToAction("FindFlights", model);

        }

        public ActionResult FindFlights(BookTicketsViewModel model)
        {
            var flight = new Flight();
            var ticket = new Ticket();
            var airportList = _airportRepo.GetAirports();


     //       ViewBag.DepartureFromId = new SelectList(airportList, "idAirport", "airportName", flight.departureFrom);
     //       ViewBag.ArrivalAtId = new SelectList(airportList, "idAirport", "airportName", flight.arriveAt);

      //      _flightRepo.GetFlightByDepartureAndArrivalHour(model.DepartOn, model.ReturnOn);
       //     _flightRepo.GetFlightByDepartureAndArrivalLocation(model.DepartureFromId, model.ArrivalAtId);
            //_flightRepo.GetFlightByDepartureAndArrivalLocation(ViewBag.DepartureFromId, ViewBag.ArrivalAtId);


            flight.Departure = _airportRepo.GetAirportById(model.DepartureFromId);
            flight.Arrival = _airportRepo.GetAirportById(model.ArrivalAtId);
            flight.departOn = model.DepartOn;
            flight.returnOn = model.ReturnOn;
            flight.price = model.Price;

            return View("BookedFlight", new List<Flight> { flight });

        }

        public ActionResult EditTicket(int id)
        {
            var getTicketById = _ticketRepo.GetTicketById(id);

            if(getTicketById == null)
            {
                return HttpNotFound();
            }

            var ticketModel = new TicketViewModel();

            ticketModel.idTicket = getTicketById.idTicket;
            ticketModel.seat = getTicketById.seat;
            ticketModel.availableTickets = getTicketById.availableTickets;
            ticketModel.totalTickets = getTicketById.totalTickets;
            ticketModel.@class = getTicketById.@class;
            ticketModel.roundTrip = getTicketById.roundTrip;

            return View("EditTicket", ticketModel);  
        }

        public ActionResult saveChanges(TicketViewModel model)
        {
            var ticket = new Ticket();

            ticket.idTicket = model.idTicket;
            ticket.seat = model.seat;
            ticket.availableTickets = model.availableTickets;
            ticket.totalTickets = model.totalTickets;
            ticket.@class = model.@class;
            ticket.roundTrip = model.roundTrip;

            _ticketRepo.EditTicketRepo(ticket);

            return RedirectToAction("Index", "Ticket");
        }

        public ActionResult CreateTicket()
       {
            return View("AddTicket", new TicketViewModel());
        }

        public ActionResult AddTicket(TicketViewModel model)
        {
            var ticket = new Ticket();

            ticket.idTicket = model.idTicket;
            ticket.seat = model.seat;
            ticket.availableTickets = model.availableTickets;
            ticket.totalTickets = model.totalTickets;
            ticket.@class = model.@class;
            ticket.roundTrip = model.roundTrip;

            _ticketRepo.InsertTicket(ticket);

            return RedirectToAction("Index", model);
        }

        public ActionResult DeleteTicket(int id)
        {
            _ticketRepo.DeleteTicket(id);

            return RedirectToAction("Index", "Ticket");
        }

    }
}