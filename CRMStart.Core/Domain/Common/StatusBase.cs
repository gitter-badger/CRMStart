namespace CRMStart.Core.Domain.Common
{
    public class StatusBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public string IsDefault { get; set; }
    }
}