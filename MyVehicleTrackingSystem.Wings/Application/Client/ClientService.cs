using System;
using System.Collections.Generic;
using Domain.Client;
using DBStorage.Client;
using System.Linq;

namespace Application.Client
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void DeleteMultipleClients(IEnumerable<int> clientsToDelete)
        {
            _clientRepository.DeleteMultipleClients(clientsToDelete);
        }

        public void EditClient(int id, Domain.Client.Client client)
        {
            _clientRepository.EditClient(id, client);
        }

        public IEnumerable<Domain.Client.Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        public Domain.Client.Client GetClientById(int id)
        {
            return _clientRepository.GetClientById(id);
        }

        public bool IsClientExists(string companyname)
        {
            return _clientRepository.IsClientExists(companyname);
        }

        public void SaveClient(Domain.Client.Client client)
        {
            _clientRepository.SaveClient(client);
        }
    }
}
