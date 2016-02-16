using System.Collections.Generic;

namespace CRMStart.Core.Domain.Contacts
{
    public class Contact
    {
        public Contact()
        {
            Roles = new List<Role>();
        }


        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }


        public virtual Customer.Customer Customer { get; set; }
        public ICollection<Role> Roles { get; set; }  

    }
}