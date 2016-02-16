using System;
using System.Collections.Generic;
using CRMStart.Core.Domain.Security;

namespace CRMStart.Core.Domain.KnowledgeBase
{
    public class Article
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string UniqueReference { get; set; } // autoIncrement or something

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public DateTime DateAdded { get; set; }

        public int VersionNumber { get; set; }

        public int TagCloud { get; set; }

        public int Approved { get; set; }


        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual UserProfile User { get; set; }
    }
}