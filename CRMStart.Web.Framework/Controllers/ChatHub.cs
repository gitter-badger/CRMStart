using Microsoft.AspNet.SignalR;

namespace CRMStart.Web.Framework.Controllers
{
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}