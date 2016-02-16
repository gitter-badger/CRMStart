using System.Data.Entity.ModelConfiguration;
using CRMStart.Core.Domain.Support;

namespace CRMStart.Data.Mapping.Support
{
    internal class SupportCategoryMap : EntityTypeConfiguration<TicketCategory>
    {
        public SupportCategoryMap()
        {
            ToTable("TicketCategories");
        }
    }
}