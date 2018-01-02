using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotfix
{
    [MessageHandler(AppType.Match)]
    public class G2Match_CreateRoomRequestHandler : AMRpcHandler<G2Match_CreateRoomRequest, Match2G_CreateRoomResponse>
    {
        protected override void Run(Session session, G2Match_CreateRoomRequest message, Action<Match2G_CreateRoomResponse> reply)
        {
            Match2G_CreateRoomResponse response = new Match2G_CreateRoomResponse();
            try
            {
                response.roomId =Game.Scene.GetComponent<MatchComponent>().Create();
                reply(response);
            }
            catch (Exception e)
            {
                ReplyError(response, e, reply);
            }
        }
    }
}
