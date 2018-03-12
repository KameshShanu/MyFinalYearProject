using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Customers;
using DBStorage.Customers;

namespace Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.RetrieveAllCustomers();
        }

        public Customer GetCustomerByPhoneNumber(string phoneNumber)
        {
            return _customerRepository.RetrieveCustomerByPhoneNumber(phoneNumber);
        }

        public void SaveCustomer(Customer customer)
        {
            _customerRepository.SaveCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteMultipleCustomers(IEnumerable<int> customersToDelete)
        {
            _customerRepository.DeleteMultipleCustomers(customersToDelete);
        }

        //Get Customer Id by phone number, if not found return 0.
        public int GetCustomerId(string phoneNumber)
        {
            if (String.IsNullOrEmpty(phoneNumber))
            {
                return 0;
            }
            var customer = _customerRepository.RetrieveCustomerByPhoneNumber(phoneNumber);
            if (customer == null)
            {
                return 0;
            }
            return customer.CustomerId;
        }
    }
}
