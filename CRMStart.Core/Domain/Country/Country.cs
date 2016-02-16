using System.Collections.Generic;

namespace CRMStart.Core.Domain.Country
{
    public class Country
    {
        public int Id { get; set; }


        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Customer.Customer> Customers { get; set; }
    }
}