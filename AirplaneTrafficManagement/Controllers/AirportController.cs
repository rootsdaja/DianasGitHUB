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
    public class AirportController : Controller
    {
         IAirportRepository _airportRepo;

        public AirportController(IAirportRepository repo)
        {
            _airportRepo = repo;
        }

        // GET: Airport
        public ActionResult Index()
        {
            var model = new AirportViewModel();

            var airportList = _airportRepo.GetAirports();
            model.AirportList = airportList;
            
            return View(model);
        }


        public ActionResult EditAirport(int id)
        {
            var getAirportById = _airportRepo.GetAirportById(id);

            if(getAirportById == null)
            {
                return HttpNotFound();
            }

            var airportModel = new AirportViewModel();

                airportModel.idAirport = getAirportById.idAirport;
                airportModel.airportName = getAirportById.airportName;
                airportModel.city = getAirportById.city;
                airportModel.country = getAirportById.country;
                airportModel.state = getAirportById.state;


                var airportList = _airportRepo.GetAirports();
                airportModel.AirportList = airportList;


            return View("EditAirport", airportModel);  
        }

        public ActionResult saveChanges(AirportViewModel model)
        {
            var airport = new Airport();

            airport.idAirport = model.idAirport;
            airport.airportName = model.airportName;
            airport.city = model.city;
            airport.country = model.country;
            airport.state = model.state;

            _airportRepo.EditAirportRepo(airport);

            return RedirectToAction("Index", "Airport");
        }

        public ActionResult CreateAirport()
       {
            return View("AddAirport", new AirportViewModel());
        }

        public ActionResult AddAirport(AirportViewModel model)
        {
            var airport = new Airport();

            airport.idAirport = model.idAirport;
            airport.airportName = model.airportName;
            airport.city = model.city;
            airport.country = model.country;
            airport.state = model.state;


            _airportRepo.InsertAirport(airport);

            return RedirectToAction("Index", model);
        }

        public ActionResult DeleteAirport(int id)
        {
             _airportRepo.DeleteAirport(id);

            return RedirectToAction("Index", "Airport");
        } 
    }
}