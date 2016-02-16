using System;
using System.ComponentModel.DataAnnotations;

namespace CRMStart.Core.Domain.Gardners.GardLink
{
    public class Support

    {
        public int Id { get; set; }

        public string Invoice { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int SupportTypeId { get; set; }
    }
}