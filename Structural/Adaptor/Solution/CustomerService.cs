using System.Collections.Generic;

namespace Adaptor.Solution
{
    public interface ICustomerService
    {
        IList<Customer> GetAllCustomers();
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICacheStorage _cacheStorage;

        public CustomerService(ICustomerRepository customerRepository, ICacheStorage cacheStorage)
        {
            _customerRepository = customerRepository;
            _cacheStorage = cacheStorage;
        }

        public IList<Customer> GetAllCustomers()
        {
            const string storageKey = "GetAllCustomers";

            IList<Customer> customers = _cacheStorage.Get<List<Customer>>(storageKey);
            
            if (customers == null)
            {
                customers = _customerRepository.GetCustomers();
                _cacheStorage.Store(storageKey, customers);
            }

            return customers;
        }
    }
}