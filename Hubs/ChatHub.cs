using ChatApi.Data;
using ChatApi.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Hubs
{
    public class ChatHub : Hub
    {
        public async Task GetNickName(string nickName)
        {
            Client client = new Client
            {
                ConnectionId = Context.ConnectionId,
                NickName = nickName,
            };

            DataSource.Clients.Add(client);
            await Clients.Others.SendAsync("clientJoined", nickName);
            await Clients.All.SendAsync("clients", DataSource.Clients);
        }

        public async Task SendMessage(string message, string clientName)
        {
            if (clientName == "Tümü")
            {
                await Clients.All.SendAsync("receiveMessage", message);
            }
            else
            {
                Client selectedClient = DataSource.Clients.FirstOrDefault(x => x.NickName == clientName);
                await Clients.Client(selectedClient.ConnectionId).SendAsync("receiveMessage", message);
            }
        }
    }
}
