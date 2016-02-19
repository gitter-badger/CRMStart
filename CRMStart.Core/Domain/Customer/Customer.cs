using System;
using System.Collections.Generic;
using CRMStart.Core.Domain.Contacts;
using CRMStart.Core.Domain.Support;

namespace CRMStart.Core.Domain.Customer
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AccountNumber { get; set; }

        public DateTime DateCreated { get; set; }

        //Could handle this better to a Many To Many relationship Table
        public bool MasterAccount { get; set; }

        public int StatusId { get; set; }

        public int CountryId { get; set; }

        public int TypeId { get; set; }


        public string FullName => $"{AccountNumber} - {Name}";


        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public virtual Status Status { get; set; }

        public virtual Country.Country Country { get; set; }

        public virtual Type Type { get; set; }

   
    }
}