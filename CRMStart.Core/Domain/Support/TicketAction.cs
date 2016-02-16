using System;
using CRMStart.Core.Domain.Security;

namespace CRMStart.Core.Domain.Support
{
    public class TicketAction
    {
        public int Id { get; set; }

        public int ActionTypeId { get; set; }

        public int TicketId { get; set; }

        public string UserId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int StatusId { get; set; }

        public string Details { get; set; }


        public virtual Ticket Ticket { get; set; }

        public virtual TicketActionType ActionType { get; set; }

        public virtual UserProfile User { get; set; }

    }
}