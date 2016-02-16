using System.Collections.Generic;

namespace CRMStart.Core.Domain.Gardners.GardLink
{
    //To be added as plugin at later date
    public class GardLink
    {
        public int Id { get; set; }

        public bool Enabled { get; set; }

        public int VersionId { get; set; }

        //Notes abstract class (Y)


        public virtual Version Version { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}