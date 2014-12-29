using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;
using Frostbite.Web.GameService;
using Microsoft.AspNet.SignalR;

namespace Frostbite.Web.Hubs
{
    public class GameHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

		public void Join(int playerId)
		{
			var client = new GameServiceClient(new InstanceContext(new GameCallback(this)));
			client.AddPlayerToLoby(playerId);
		}

	    public override async Task OnConnected()
	    {

		    await base.OnConnected();
	    }
    }

	public class GameCallback : IGameServiceCallback
	{
		private readonly GameHub _gameHub;
		public GameCallback(GameHub gameHub)
		{
			_gameHub = gameHub;
		}

		public void StartGame(int gameId)
		{
			_gameHub.Send("System", "GameStarted");
		}
	}
}