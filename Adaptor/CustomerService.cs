using System.Collections.Generic;
using System.Web;

namespace Adaptor
{
    public interface ICustomerService
    {
        IList<Customer> GetAllCustomers();
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IList<Customer> GetAllCustomers()
        {
            const string storageKey = "GetAllCustomers";

            IList<Customer> customers = (List<Customer>)HttpContext.Current.Cache.Get(storageKey);

            if (customers == null)
            {
                customers = _customerRepository.GetCustomers();
                HttpContext.Current.Cache.Insert(storageKey, customers);
            }

            return customers;
        }
    }
}