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
    public class RouteController : Controller
    {   
         IRouteRepository _routeRepository;

        public RouteController(IRouteRepository repo)
        {
            _routeRepository = repo;
        }

         // GET: /Route/
        public ActionResult Index()
        {
            var model = new RouteViewModel();
            model._routeList = new List<RouteViewModel>();

            var route = new Route();
            var routeListRepo = _routeRepository.GetRoutes();

            foreach(var item in routeListRepo)
            {
                var routeModel = new RouteViewModel();

                routeModel.idRoute = item.idRoute;
                routeModel.leavingFrom = item.leavingFrom;
                routeModel.goingTo = item.goingTo;
                routeModel.leavingHour = item.leavingHour;
                routeModel.arrivalHour = item.arrivalHour;
       
                
                model._routeList.Add(routeModel);
            }
            return View(model);
        }


        public ActionResult EditRoute(int id)
        {
            var getRouteById = _routeRepository.GetRouteById(id);

            if(getRouteById == null)
            {
                return HttpNotFound();
            }

            var routeModel = new RouteViewModel();

            routeModel.idRoute = getRouteById.idRoute;
            routeModel.leavingFrom = getRouteById.leavingFrom;
            routeModel.goingTo = getRouteById.goingTo;
            routeModel.leavingHour = getRouteById.leavingHour;
            routeModel.arrivalHour = getRouteById.arrivalHour;

            return View("EditRoute", routeModel);  
        }

        public ActionResult saveChanges(RouteViewModel model)
        {
            var route = new Route();

            route.idRoute = model.idRoute;
            route.leavingFrom = model.leavingFrom;
            route.goingTo = model.goingTo;
            route.leavingHour = model.leavingHour;
            route.arrivalHour = model.arrivalHour;

            _routeRepository.EditRouteRepo(route);

            return RedirectToAction("Index", "Route");
        }

        public ActionResult CreateRoute()
       {
            return View("AddRoute", new RouteViewModel());
        }

        public ActionResult AddRoute(RouteViewModel model)
        {
            var route = new Route();

            route.idRoute = model.idRoute;
            route.leavingFrom = model.leavingFrom;
            route.goingTo = model.goingTo;
            route.leavingHour = model.leavingHour;
            route.arrivalHour = model.arrivalHour;

            _routeRepository.InsertRoute(route);

            return RedirectToAction("Index", model);
        }

        public ActionResult DeleteRoute(int id)
        {
             _routeRepository.DeleteRoute(id);

            return RedirectToAction("Index", "Route");
        }
    }
}
