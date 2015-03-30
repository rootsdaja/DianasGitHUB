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
    public class ClientController : Controller
    {
        // GET: Client
        IClientRepository _clientRepo;

        public ClientController(IClientRepository repo)
        {
            _clientRepo = repo;
        }

        // GET: Airport
        public ActionResult Index()
        {
            var model = new ClientViewModel();
            model._clientList = new List<ClientViewModel>();

            var client = new Client();

            var clientListRepo = _clientRepo.GetClients();
            foreach(var item in clientListRepo)
            {
                var clientModel = new ClientViewModel();

                clientModel.idClient = item.idClient;
                clientModel.firstName = item.firstName;
                clientModel.lastName = item.lastName;
                clientModel.username = item.username;
                clientModel.password = item.password;
                clientModel.email = item.email;
                clientModel.phone = item.phone;
                clientModel.city = item.city;

                model._clientList.Add(clientModel);
            }
            return View(model);
        }


        public ActionResult EditClient(int id)
        {
            var getClienttById = _clientRepo.GetClientById(id);

            if(getClienttById == null)
            {
                return HttpNotFound();
            }

            var clientModel = new ClientViewModel();

            clientModel.idClient = getClienttById.idClient;
            clientModel.firstName = getClienttById.firstName;
            clientModel.lastName = getClienttById.lastName;
            clientModel.username = getClienttById.username;
            clientModel.password = getClienttById.password;
            clientModel.email = getClienttById.email;
            clientModel.phone = getClienttById.phone;
            clientModel.city = getClienttById.city;

            return View("EditClient", clientModel);  
        }

        public ActionResult saveChanges(ClientViewModel model)
        {
            var client = new Client();

            client.idClient = model.idClient;
            client.firstName = model.firstName;
            client.lastName = model.lastName;
            client.username = model.username;
            client.password = model.password;
            client.email = model.email;
            client.phone = model.phone;
            client.city = model.city;

            _clientRepo.EditClientRepo(client);

            return RedirectToAction("Index", "Client");
        }

        public ActionResult CreateClient()
       {
            return View("AddClient", new ClientViewModel());
        }

        public ActionResult AddClient(ClientViewModel model)
        {
            var client = new Client();

            client.idClient = model.idClient;
            client.firstName = model.firstName;
            client.lastName = model.lastName;
            client.username = model.username;
            client.password = model.password;
            client.email = model.email;
            client.phone = model.phone;
            client.city = model.city;

            _clientRepo.InsertClient(client);

            return RedirectToAction("Index", model);
        }

        public ActionResult DeleteClient(int id)
        {
             _clientRepo.DeleteClient(id);

            return RedirectToAction("Index", "Client");
        } 
    }
}