using CRMStart.Core.Domain.Common;

namespace CRMStart.Core.Domain.Gardners.DataServices
{
    public class OrderFtp : Ftp
    {
        public int Id { get; set; }

        public int EdiId { get; set; }

        public virtual Edi Edi { get; set; }
    }
}