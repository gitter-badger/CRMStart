using System.Collections.Generic;
using CRMStart.Core.Domain.Common;

namespace CRMStart.Core.Domain.KnowledgeBase
{
    public class Category : CategoryBase
    {
        public int SectionId { get; set; }

        public virtual Section Section { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}