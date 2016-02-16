using System.Collections.Generic;

namespace CRMStart.Core.Domain.Contacts
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public ICollection<Contact> Contacts { get; set; } 
    }
}