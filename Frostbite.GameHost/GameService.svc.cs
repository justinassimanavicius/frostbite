﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Frostbite.Lobby;

namespace Frostbite.GameHost
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class GameService : IGameService
    {
        
        private readonly SingleSeatLobby _lobby = new SingleSeatLobby();

        public void AddPlayerToLoby(int playerId)
        {
            var client = new GameClient(Callback);
            _lobby.AddWaitingPlayer(playerId, client);
        }

        IGameCallbackService Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IGameCallbackService>();
            }
        }
    }

    public class GameClient : IGameClient
    {
        private readonly IGameCallbackService _callback;

        public GameClient(IGameCallbackService callback)
        {
            _callback = callback;
        }

        public void StartGame(int gameId)
        {
            _callback.StartGame(gameId);
        }
    }
}
