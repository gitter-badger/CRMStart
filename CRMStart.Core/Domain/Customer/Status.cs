using System.Collections.Generic;
using CRMStart.Core.Domain.Common;

namespace CRMStart.Core.Domain.Customer
{
    public class Status : StatusBase
    {
        public virtual ICollection<Customer> Customers { get; set; }
    }
}