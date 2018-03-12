using System.Collections.Generic;
using DBStorage.Common;
using Domain.Client;
using System.Linq;
using System.Data;

namespace DBStorage.Client
{
    public class ClientRepository : Repository<Domain.Client.Client>, IClientRepository
    {
        public ClientRepository(WingsContext context) : base(context)
        {
        }

        public void DeleteMultipleClients(IEnumerable<int> clientsToDelete)
        {           
            using (WingsContext context = new WingsContext())
            {
                context.Client.Where(d => clientsToDelete.Contains(d.ClientId)).ToList().ForEach(d =>
                {
                    d.IsDeleted = true;
                });            
                context.Commit();
            }
        }

        public void EditClient(int id, Domain.Client.Client client)
        {
            Domain.Client.Client clientp = RetrieveByKey(id);

            clientp.CompanyName = client.CompanyName;
            clientp.CompanyAddress = client.CompanyAddress;
            clientp.PhoneNumber1 = client.PhoneNumber1;
            clientp.PhoneNumber2 = client.PhoneNumber2;
            clientp.VAT = client.VAT;
            clientp.SVAT = client.SVAT;
            clientp.ClientRate = client.ClientRate;
            clientp.DriverCommissionRate = client.DriverCommissionRate;
            clientp.PorterCommissionRate = client.PorterCommissionRate;
            clientp.OperationType = client.OperationType;
            Save(clientp);
        }

        public IEnumerable<Domain.Client.Client> GetAllClients()
        {
            return Retrieve(f => f.IsDeleted == false);
        }

        public Domain.Client.Client GetClientById(int id)
        {
            return Retrieve(a => a.ClientId == id).SingleOrDefault();
        }

        public bool IsClientExists(string companyname)
        {
            return !Context.Client.Any(x => (x.CompanyName == companyname) && x.IsDeleted.Equals(false));
        }

        public void SaveClient(Domain.Client.Client client)
        {
            Save(client);
        }
    }
}
