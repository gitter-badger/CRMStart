using System.Collections.Generic;
using CRMStart.Core.Domain.Common;

namespace CRMStart.Core.Domain.Tasks
{
    public class Priority : StatusBase
    {
        public virtual  ICollection<Project> Projects { get; set; } 

    }
}