using Domin.Common;
using System.Collections.Generic;

namespace Domain.Client
{
    public interface IClientRepository : IRepository<Client>
    {
        IEnumerable<Client> GetAllClients();
        void DeleteMultipleClients(IEnumerable<int> clientsToDelete);
        bool IsClientExists(string companyname);
        void SaveClient(Client client);
        Domain.Client.Client GetClientById(int id);
        void EditClient(int id, Domain.Client.Client client);
    }
}
