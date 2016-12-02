using System.Collections.Generic;

namespace Adaptor.Solution
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
