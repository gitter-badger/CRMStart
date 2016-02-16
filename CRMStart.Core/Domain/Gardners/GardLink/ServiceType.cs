using System;
using System.Collections.Generic;

namespace CRMStart.Core.Domain.Gardners.GardLink
{
    public class ServiceType

    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}