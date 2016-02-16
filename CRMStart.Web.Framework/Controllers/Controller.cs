using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CRMStart.Data;
using Microsoft.AspNet.Identity;

namespace CRMStart.Web.Framework.Controllers
{
    public  partial class BaseController : System.Web.Mvc.Controller
    {
        public CrmStartObjectContext Db = new CrmStartObjectContext();

        public void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

    }
}
