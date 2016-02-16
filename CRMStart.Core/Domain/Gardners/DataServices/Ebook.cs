using System;

namespace CRMStart.Core.Domain.Gardners.DataServices
{
    public class Ebook

    {
        public int Id { get; set; }

        public string AccNumber { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public DateTime Livedate { get; set; }
        public bool Report { get; set; }
        public bool Testing { get; set; }
    }
}