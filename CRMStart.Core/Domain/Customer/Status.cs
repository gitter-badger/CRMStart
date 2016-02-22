using System.Collections.Generic;
using CRMStart.Core.Domain.Common;

namespace CRMStart.Core.Domain.Customer
{
    public class CustomerStatus : StatusBase
    {
        public virtual ICollection<Customer> Customers { get; set; }
    }
}