using Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerByPhoneNumber(string phoneNumber);
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteMultipleCustomers(IEnumerable<int> customersToDelete);
        int GetCustomerId(string phoneNumber);
    }
}
