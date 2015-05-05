using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    public class ClientRepository : IClientRepository
    {
         private AirplaneTrafficEntities _context;

 
         public ClientRepository()
        {
            _context = new AirplaneTrafficEntities();
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Client.ToList();
        }

        public Client GetClientsById(int id)
        {
            return _context.Client.Find(id);
        }

        public List<Client> GetClientsByName(string fName, string lName)
        {
            return _context.Client.Where(c => c.firstName.Equals(fName) && c.lastName.Equals(lName)).ToList();
        }


        public List<Client> SearchClientsByName(string _searchValue)
        {
            return _context.Client.Where(a => a.lastName.StartsWith(_searchValue) && 
                a.firstName.StartsWith(_searchValue)).ToList();
        }

        public Client logIn(string username, string password)
        {
            var log = _context.Client.FirstOrDefault(d => d.username == username && d.password == password);

            if (log != null)
            {
                return log;
            }
            else return null;
        }

        public string registerClients(string firstName, string lastName, string username, string password, string confirmPassword, string email, string address, int? phone, string city, string userType)
        {
            var clients = new Client {
                firstName = firstName, 
                lastName = lastName, 
                username = username, 
                password = password,
                confirmPassword = confirmPassword,
                email = email, 
                address = address, 
                phone = phone, 
                city = city,
                userType = userType
            };

            _context.Client.Add(clients);
            _context.SaveChanges();

            return string.Format("You entered: {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", 
                firstName, lastName, username,
                password, confirmPassword, email, address, phone, city, userType);
        }

        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

        public void InsertClient(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
        }

        public void DeleteClient(int clientId)
        {
            var client = _context.Client.Find(clientId);
            _context.Client.Remove(client);
            _context.SaveChanges();
        }

        public void UpdateClients(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void EditClientRepo(Client client)
        {
            var clientId = _context.Client.FirstOrDefault(f => f.idClient == client.idClient);

            clientId.idClient = client.idClient;
            clientId.firstName = client.firstName;
            clientId.lastName = client.lastName;
            clientId.username = client.username;
            clientId.password = client.password;
            clientId.email = client.email;
            clientId.phone = client.phone;
            clientId.city = client.city;

            _context.SaveChanges();
        }


        public Client GetClientById(int id)
        {
            throw new NotImplementedException();
        }


        public string registerClients(string firstName, string lastName, string username, string password, string confirmPassword, string email, string address, int phone, string city, string userType)
        {
            throw new NotImplementedException();
        }
    }
}