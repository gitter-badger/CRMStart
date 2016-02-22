using System;

namespace CRMStart.Core.Domain.Tasks
{
    public class Action
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int Type { get; set; } 

        public virtual ProjectStatus Status { get; set; }
        public virtual Project Project { get; set; }
    }
}