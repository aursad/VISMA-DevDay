using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DevDay.Controllers.Hubs
{
    [HubName("RetroHub")]
    public class RetroHub : Hub
    {

        public void NotifyUpdated(int retroId)
        {
            Clients.All.BoardUpdated();
        }

        public void JoinGame()
        {
            Clients.All.NewMember();
        }

    }
}
