using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EUC.Profile.Buddy.Web.Hubs
{
    public class EUCProfileBuddyHub : Hub
    {
        public Task SendMessage(string message, string user)
        {
            return Clients.All.SendAsync(method: "ReceiveMessage", message, user);
        }
    }
}
