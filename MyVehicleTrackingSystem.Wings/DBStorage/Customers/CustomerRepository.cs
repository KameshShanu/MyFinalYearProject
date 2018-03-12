using DBStorage.Common;
using Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Common;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;

namespace DBStorage.Customers
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(WingsContext context) : base(context)
        {
        }

        private IDbConnection GetConnection()
        {
            var connection = new SqlConnection();
            WingsContext wings = WingsContext.GetInstance();
            connection.ConnectionString = wings.Database.Connection.ConnectionString;
            connection.Open();
            return connection;
        }        

        public IEnumerable<Customer> RetrieveAllCustomers()
        {
            return Context.Set<Customer>().Where(c => c.IsDeleted == false);
        }

        public Customer RetrieveCustomerByPhoneNumber(string phoneNumber)
        {
            return Context.Set<Customer>().Where(a => a.PhoneNumber == phoneNumber && a.IsDeleted == false).FirstOrDefault();
        }

        public void SaveCustomer(Customer customer)
        {
            Save(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer cust = Context.Customer.Where(c => c.PhoneNumber == customer.PhoneNumber).FirstOrDefault();
            cust.PhoneNumber = customer.PhoneNumber;
            cust.FirstName = customer.FirstName;
            cust.LastName = customer.LastName;
            cust.Email = customer.Email;
            cust.Address = customer.Address;
            Context.Commit();
        }

        public void DeleteMultipleCustomers(IEnumerable<int> customersToDelete)
        {
            Context.Customer.Where(c => customersToDelete.Contains(c.CustomerId)).ToList().ForEach(c => c.IsDeleted = true);
            Context.Commit();
        }        
    }
}
