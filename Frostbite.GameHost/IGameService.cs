using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Frostbite.GameHost
{
    [ServiceContract(SessionMode = SessionMode.Required,
                 CallbackContract = typeof(IGameCallbackService))]
    public interface IGameService
    {

        [OperationContract]
        void AddPlayerToLoby(int playerId);

    }

    public interface IGameCallbackService
    {
        [OperationContract(IsOneWay = true)]
        void StartGame(int gameId);
    }


}
