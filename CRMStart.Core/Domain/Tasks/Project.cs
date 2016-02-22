using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMStart.Core.Domain.Tasks
{
    public class Project
    {
        public int Id  { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }


        public DateTime DueDate { get; set; }
        public int? CustomerId { get; set; }
        
        public int ContactType { get; set; }
        public int PriorityId { get; set; }
        public int Statusid { get; set; }

        public string Description { get; set; }


        public virtual Priority Priority { get; set; }
        public virtual ProjectStatus Status { get; set; }
       public virtual ICollection<Action> Actions { get; set; } 
    }
}
