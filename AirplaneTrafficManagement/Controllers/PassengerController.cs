using AirplaneTrafficManagement.Database;
using AirplaneTrafficManagement.Models;
using AirplaneTrafficManagement.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirplaneTrafficManagement.Controllers
{
    public class PassengerController : Controller
    {
       
        IPassengerRepository _passengerRepository;

        public PassengerController(IPassengerRepository repo)
        {
            _passengerRepository = repo;
        }

         // GET: Passenger
        public ActionResult Index()
        {
            var flightList = _passengerRepository.GetPassengers();
            return View(flightList);       
        }


        public ActionResult EditPassenger(int id)
        {
            var getPassengerByID = _passengerRepository.GetPassengerById(id);

            if(getPassengerByID == null)
            {
                return HttpNotFound();
            }

            var passModel = new PassengerViewModel();

            passModel.idPassenger = getPassengerByID.idPassenger;
            passModel.adult = getPassengerByID.adult;
            passModel.children = getPassengerByID.children;
            passModel.infants = getPassengerByID.infants;

            return View("EditPassenger", passModel);  
        }

        public ActionResult saveChanges(PassengerViewModel model)
        {
            var passModel = new Passenger();

            passModel.idPassenger = model.idPassenger;
            passModel.adult = model.adult;
            passModel.children = model.children;
            passModel.infants = model.infants;

            _passengerRepository.EditPassengerRepo(passModel);

            return RedirectToAction("Index", "Passenger");
        }

        public ActionResult CreateRoute()
       {
            return View("AddPassenger", new PassengerViewModel());
        }

        public ActionResult AddRoute(PassengerViewModel model)
        {
            var passModel = new Passenger();

            passModel.idPassenger = model.idPassenger;
            passModel.adult = model.adult;
            passModel.children = model.children;
            passModel.infants = model.infants;

            _passengerRepository.InsertPassenger(passModel);

            return RedirectToAction("Index", model);
        }

        public ActionResult DeletePassenger(int id)
        {
             _passengerRepository.DeletePassenger(id);

            return RedirectToAction("Index", "Passenger");
        }
    }
}
