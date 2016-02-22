using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMStart.Core.Domain.Security
{
   public class Team
   {
       public int Id { get; set; }

       public string Name { get; set; }

       public int DateCreated { get; set; }
       
        



        public ICollection<CrmStartUser> Users { get; set; }
         
    }
}
