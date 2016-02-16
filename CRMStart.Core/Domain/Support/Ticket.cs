using System;
using System.Collections.Generic;

namespace CRMStart.Core.Domain.Support
{
    public class Ticket
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int? CustomerId { get; set; }

        public int ContactId { get; set; }

        public int StatusId { get; set; }

        public string Report { get; set; }

        public bool Urgent { get; set; }

        public DateTime DateAdded { get; set; }

        //Last Modified and last modifiyed by, get latest action


        public virtual ICollection<TicketAction> Actions { get; set; }
        public virtual Customer.Customer Customer { get; set; }
        public virtual TicketStatus Status { get; set; }
        public virtual TicketCategory Category { get; set; }
    }
}