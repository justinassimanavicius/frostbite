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
		public void StartGame(dynamic caller, string message)
		{
			// Call the broadcastMessage method to update clients.
			caller.broadcastMessage("GameMaster", message);
		}


		public void Join(int playerId)
		{
			var caller = Clients.Caller;
			var client = new GameServiceClient(new InstanceContext(new GameCallback(this, caller)));
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
		private readonly dynamic _caller;

		public GameCallback(GameHub gameHub, dynamic caller)
		{
			_gameHub = gameHub;
			_caller = caller;
		}

		public void StartGame(int gameId)
		{
			_gameHub.StartGame(_caller, "GameStarted");
		}
	}
}