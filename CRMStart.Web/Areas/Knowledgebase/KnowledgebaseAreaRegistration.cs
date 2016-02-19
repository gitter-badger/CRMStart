using System.Web.Mvc;

namespace CRMStart.Web.Areas.Knowledgebase
{
    public class KnowledgebaseAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Knowledgebase";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Knowledgebase_default",
                "HelpDesk/Knowledgebase/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}