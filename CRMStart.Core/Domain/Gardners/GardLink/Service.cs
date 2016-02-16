namespace CRMStart.Core.Domain.Gardners.GardLink
{
    public class Service
    {
        public int Id { get; set; }

        public int ServiceTypeId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Other { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual GardLink GardLink { get; set; }
    }
}