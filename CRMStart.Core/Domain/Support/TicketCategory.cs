using System.Collections.Generic;
using CRMStart.Core.Domain.Common;

namespace CRMStart.Core.Domain.Support
{
    public class TicketCategory : CategoryBase
    {
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}