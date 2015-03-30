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

        //Prin constructorul asta, tu tot ce faci in controller, se ataseaza la constructor
        //si apoi la Interfata si din interfata in Repositoryul asociat interfetei
        public FlightController(IFlightRepository repo)
        {
            _flightRepo = repo;
        }

        // GET: Airplane
        public ActionResult Index()
        {
            var model = new FlightViewModel();
            model._flightList = new List<FlightViewModel>();

            var flight = new Flight();

            var flightListRepo = _flightRepo.GetFlights();
            foreach(var item in flightListRepo)
            {
                var flightModel = new FlightViewModel();

                flightModel.idFlight = item.idFlight;
                flightModel.departureFrom = item.departureFrom;
                flightModel.arriveAt = item.arriveAt;
                flightModel.departOn = item.departOn;
                flightModel.returnOn = item.returnOn;
                flightModel.time = item.time;

                model._flightList.Add(flightModel);
            }
            return View(model);
        }


        public ActionResult EditFlight(int id)
        {
            var getFlightById = _flightRepo.GetFlightById(id);

            if(getFlightById == null)
            {
                return HttpNotFound();
            }

            var flightModel = new FlightViewModel();

            flightModel.idFlight = getFlightById.idFlight;
            flightModel.departureFrom = getFlightById.departureFrom;
            flightModel.arriveAt = getFlightById.arriveAt;
            flightModel.departOn = getFlightById.departOn;
            flightModel.returnOn = getFlightById.returnOn;
            flightModel.time = getFlightById.time;

            return View("EditFlight", flightModel);  
        }

        public ActionResult saveChanges(FlightViewModel model)
        {
            var flight = new Flight();

            flight.idFlight = model.idFlight;
            flight.departureFrom = model.departureFrom;
            flight.arriveAt = model.arriveAt;
            flight.departOn = model.departOn;
            flight.returnOn = model.returnOn;
            flight.time = model.time;

            _flightRepo.EditFlightRepo(flight);

            return RedirectToAction("Index", "Flight");
        }

        public ActionResult CreateFlight()
       {
            return View("AddFlight", new FlightViewModel());
        }

        public ActionResult AddFlight(FlightViewModel model)
        {
            var flight = new Flight();

            flight.idFlight = model.idFlight;
            flight.departureFrom = model.departureFrom;
            flight.arriveAt = model.arriveAt;
            flight.departOn = model.departOn;
            flight.returnOn = model.returnOn;
            flight.time = model.time;

            _flightRepo.InsertFlight(flight);

            return RedirectToAction("Index", model);
        }

        public ActionResult DeleteFlight(int id)
        {
             _flightRepo.DeleteFlight(id);

            return RedirectToAction("Index", "Flight");
        }

   
    }
}