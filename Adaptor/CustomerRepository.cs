using System.Collections.Generic;

namespace Adaptor
{
    public interface ICustomerRepository
    {
        IList<Customer> GetCustomers();
    }

    class CustomerRepository : ICustomerRepository
    {
        public IList<Customer> GetCustomers()
        {
            return new List<Customer>();    
        }
    }
}
