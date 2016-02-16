using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CRMStart.Core.Domain.KnowledgeBase;
using CRMStart.Core.Domain.Support;

namespace CRMStart.Core.Domain.Security
{
    public class UserProfile
    {
        public UserProfile()
        {
            JoinDate = DateTime.Now;
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public string JobTitle { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => FirstName + " " + LastName;

        [DataType(DataType.Date)]
        [Required]
        public DateTime JoinDate { get; set; }

        public virtual ICollection<TicketAction> Actions { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}