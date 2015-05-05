using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirplaneTrafficManagement.Database;
using AirplaneTrafficManagement.Repo;
using AirplaneTrafficManagement.Models;

namespace AirplaneTrafficManagement.Controllers
{
    public class FlightController : Controller
    {
        IFlightRepository _flightRepo;
        IAirportRepository _airportRepo;

        public FlightController(IFlightRepository repo, IAirportRepository airportRepo)
        {
            _flightRepo = repo;
            _airportRepo = airportRepo;
        }
        
        // GET: Airplane
        public ActionResult Index()
        {
            var flightList = _flightRepo.GetFlights();

            return View(flightList);
        }
 
        public ActionResult EditFlight(int id)
        {
            var flight = _flightRepo.GetFlightById(id);
            var airportList = _airportRepo.GetAirports();

            if (flight == null)
            {
                return HttpNotFound();
            }

            var flightModel = new FlightViewModel();

            flightModel.idFlight = flight.idFlight;
            flightModel.DepartureFromId = flight.departureFrom ?? 0;
            flightModel.ArrivalAtId = flight.arriveAt ?? 0;
            flightModel.departOn = flight.departOn;
            flightModel.returnOn = flight.returnOn;


            ViewBag.DepartureFromId = new SelectList(airportList, "idAirport", "airportName", flight.departureFrom);
            ViewBag.ArrivalAtId = new SelectList(airportList, "idAirport", "airportName", flight.arriveAt);
    
            return View("EditFlight", flightModel);  
        }

        public ActionResult SaveChanges(FlightViewModel model)
        {
            var flight = _flightRepo.GetFlightById(model.idFlight);

            flight.departureFrom = model.DepartureFromId;
            flight.arriveAt = model.ArrivalAtId;
            flight.departOn = model.departOn;
            flight.returnOn = model.returnOn;

            _flightRepo.Save();

            return RedirectToAction("Index", "Flight");
        }

        public ActionResult CreateFlight()
        {
            return View("AddFlight", new FlightViewModel());
        }

        public ActionResult AddFlight(FlightViewModel model)
        {
            var flight = new Flight();
            var airportDeparture = new Airport();

            airportDeparture.airportName = model.DepartureFromAirport.airportName;
            airportDeparture.idAirport = model.DepartureFromAirport.idAirport;
            airportDeparture.city = model.DepartureFromAirport.city;
            airportDeparture.country = model.DepartureFromAirport.country;
            airportDeparture.state = model.DepartureFromAirport.state;

            var airportArrival = new Airport();

            airportArrival.airportName = model.ArrivalAtAirport.airportName;
            airportArrival.idAirport = model.ArrivalAtAirport.idAirport;
            airportArrival.city = model.ArrivalAtAirport.city;
            airportArrival.country = model.ArrivalAtAirport.country;
            airportArrival.state = model.ArrivalAtAirport.state;

            _airportRepo.InsertAirport(airportDeparture);
            _airportRepo.InsertAirport(airportArrival);

            flight.Departure = airportDeparture;
            flight.Arrival = airportArrival;
            flight.departOn = model.departOn;
            flight.returnOn = model.returnOn;
            
            _flightRepo.InsertFlight(flight);

            return RedirectToAction("Index", flight);
        }

        public ActionResult DeleteFlight(int id)
        {
             _flightRepo.DeleteFlight(id);

            return RedirectToAction("Index", "Flight");
        }


        //public ActionResult searchFlight(FlightViewModel model)
        //{
        //    var result = new FlightViewModel();
        //    result. = new List<DriverModel>();

        //    var driversList = _service.getDriverByName(model._searchValue);

        //    if (model._searchValue == null)
        //    {
        //        return RedirectToAction("Index", "Driver");
        //    }

        //    else
        //    {

        //        foreach (var item in driversList)
        //        {
        //            var driverModel = new DriverModel();

        //            driverModel.id_driver = item.id_driver;
        //            driverModel.username = item.username;
        //            driverModel.password = item.password;
        //            driverModel.email = item.email;
        //            driverModel.address = item.address;
        //            driverModel.phone = item.phone;
        //            driverModel.user_type = item.user_type;

        //            result._driverList.Add(driverModel);

        //        }
        //        return View("Index", result);
        //    }
        //}
    }
}