using System.Collections.Generic;

namespace CRMStart.Core.Domain.KnowledgeBase
{
    public class Section
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Archived { get; set; }

        //add role restrictions

        public virtual ICollection<Category> Categories { get; set; }
    }
}