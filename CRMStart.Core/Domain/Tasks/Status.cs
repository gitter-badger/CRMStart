using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CRMStart.Core.Domain.Common;

namespace CRMStart.Core.Domain.Tasks
{
 
    public class ProjectStatus : StatusBase
    {

       
        public virtual ICollection<Project> Projects { get; set; } 
    }
}