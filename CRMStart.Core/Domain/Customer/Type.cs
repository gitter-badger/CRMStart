using System.Collections.Generic;

namespace CRMStart.Core.Domain.Customer
{
    public class Type
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public ICollection<Customer> Customers { get; set; }
    }
}