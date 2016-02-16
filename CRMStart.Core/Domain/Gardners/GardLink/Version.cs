using System;

namespace CRMStart.Core.Domain.Gardners.GardLink
{
    public class Version
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual GardLink GardLink { get; set; }
    }
}