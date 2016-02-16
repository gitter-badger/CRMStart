using System.Data.Entity.ModelConfiguration;

namespace CRMStart.Data.Mapping.Customer
{
    internal class CustomerMap : EntityTypeConfiguration<Core.Domain.Customer.Customer>
    {
        public CustomerMap()
        {
            HasOptional(x => x.Edis)
                .WithRequired(c => c.Customer);

        }
    }
}