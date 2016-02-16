using System.Data.Entity.ModelConfiguration;
using CRMStart.Core.Domain.Gardners.DataServices;

namespace CRMStart.Data.Mapping.Gardners.DataServices
{
    public class EDIMap : EntityTypeConfiguration<Edi>
    {
        public EDIMap() 
        {
            this.HasKey(duh => duh.Id);
 
            
        }
    }
}