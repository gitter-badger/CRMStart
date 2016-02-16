using System.Collections.Generic;

namespace CRMStart.Core.Domain.Gardners.DataServices
{
    public class Edi
    {
        
        public int Id { get; set; }

        public int DataFtpId { get; set; }

        public int OrderFtpId { get; set; }

        public bool HomeDel { get; set; }

        public bool StockOrd { get; set; }

        //Notes

        public virtual ICollection<OrderFtp> OrderFtps { get; set; }

        public virtual ICollection<DataFtp> DataFtps { get; set; }

        public virtual Customer.Customer Customer { get; set; }
    }
}