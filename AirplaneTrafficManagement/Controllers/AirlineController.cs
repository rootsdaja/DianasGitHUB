
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
    public class AirlineController : Controller
    {
        IAirlineRepository _airlineRepo;

        //Prin constructorul asta, tu tot ce faci in controller, se ataseaza la constructor
        //si apoi la Interfata si din interfata in Repositoryul asociat interfetei
        public AirlineController(IAirlineRepository repo)
        {
            _airlineRepo = repo;
        }

        // GET: Airline
        public ActionResult Index()
        {
            var airlineList = _airlineRepo.GetAirlines();
            return View(airlineList);
        }


        public ActionResult EditAirline(int id)
        {
            var getAirlineById = _airlineRepo.GetAirlineById(id);

            if(getAirlineById == null)
            {
                return HttpNotFound();
            }

            var airlineModel = new AirlineViewModel();

            airlineModel.idAirline = getAirlineById.idAirline;
            airlineModel.companyName = getAirlineById.companyName;
            airlineModel.logo = getAirlineById.logo;

            return View("EditAirline", airlineModel);  
        }

        public ActionResult saveChanges(AirlineViewModel model)
        {
            var airline = new Airline();

            airline.idAirline = model.idAirline;
            airline.companyName = model.companyName;
            airline.logo = model.logo;

            _airlineRepo.EditAirlinetRepo(airline);

            return RedirectToAction("Index", "Airline");
        }

        public ActionResult CreateAirline()
       {
            return View("AddAirline", new AirlineViewModel());
        }

        public ActionResult AddAirline(AirlineViewModel model)
        {
            var airline = new Airline();

            airline.idAirline = model.idAirline;
            airline.companyName = model.companyName;
            airline.logo = model.logo; ;


            _airlineRepo.InsertAirline(airline);

            return RedirectToAction("Index", model);
        }

        public ActionResult DeleteAirline(int id)
        {
             _airlineRepo.DeleteAirline(id);

            return RedirectToAction("Index", "Airline");
        }

   
    }
}