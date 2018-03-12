using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client
{
    public interface IClientService
    {
        IEnumerable<Domain.Client.Client> GetAllClients();
        void DeleteMultipleClients(IEnumerable<int> clientsToDelete);
        bool IsClientExists(string companyname);
        void SaveClient(Domain.Client.Client client);
        Domain.Client.Client GetClientById(int id);
        void EditClient(int id, Domain.Client.Client client);
    }
}
