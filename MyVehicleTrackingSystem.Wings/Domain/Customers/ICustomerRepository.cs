using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> RetrieveAllCustomers();
        Customer RetrieveCustomerByPhoneNumber(string phoneNumber);
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteMultipleCustomers(IEnumerable<int> customersToDelete);
    }
}
