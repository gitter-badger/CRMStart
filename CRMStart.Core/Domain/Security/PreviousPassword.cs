using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMStart.Core.Domain.Security
{
    public class PreviousPassword
    {
        public PreviousPassword()
        {
            CreateDate = DateTimeOffset.Now;
        }

        [Key, Column(Order = 0)]
        public string PasswordHash { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        [Key, Column(Order = 1)]
        public string UserId { get; set; }

        public virtual CrmStartUser User { get; set; }
    }
}