using System;

namespace CRMStart.Core.Domain.Notes
{
    public class Note
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Text { get; set; }

        public DateTime DateAdded { get; set; }

        public int Order { get; set; }
    }
}