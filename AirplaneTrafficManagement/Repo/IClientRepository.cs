using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTrafficManagement.Repo
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClientById(int id);
        List<Client> GetClientsByName(string fName, string lName);
        List<Client> SearchClientsByName(string _searchValue);
        void InsertClient(Client client);
        void DeleteClient(int clientId);
        void UpdateClients(Client client);
        void Save();
        void EditClientRepo(Client flight);

    }
}
