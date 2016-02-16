using System;
using CRMStart.Core.Domain.Security;

namespace CRMStart.Core.Domain.KnowledgeBase
{
    public class Comment
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public DateTime DatePosted { get; set; }


        public virtual UserProfile User { get; set; }

        public virtual Article Article { get; set; }
    }
}