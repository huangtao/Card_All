using Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Hotfix
{
    [MessageHandler(AppType.Gate)]
    public class C2G_CreateLandlordRoomHandler : AMHandler<C2G_CreateLandlordRoom>
    {
        protected override async void Run(Session session, C2G_CreateLandlordRoom message)
        {
            G2C_EnterMap response = new G2C_EnterMap();
            try
            {
                Log.Debug(MongoHelper.ToJson(message));
                Player player = session.GetComponent<SessionPlayerComponent>().Player;
                StartConfigComponent startConfigComponet = Game.Scene.GetComponent<StartConfigComponent>();
                IPEndPoint matchAddress = startConfigComponet.MatchConfig.GetComponent<InnerConfig>().IPEndPoint;
                Match2G_CreateRoomResponse matchRoomRes = await Game.Scene.GetComponent<NetInnerComponent>().Get(matchAddress).Call<Match2G_CreateRoomResponse>(new G2Match_CreateRoomRequest());
                long roomId = matchRoomRes.roomId;

                // 在map服务器上创建战斗Unit
                IPEndPoint mapAddress = startConfigComponet.MapConfigs[0].GetComponent<InnerConfig>().IPEndPoint;
                Session mapSession = Game.Scene.GetComponent<NetInnerComponent>().Get(mapAddress);
                M2G_CreateUnit createUnit = await mapSession.Call<M2G_CreateUnit>(new G2M_CreateUnit() { PlayerId = player.Id, GateSessionId = session.Id });
                //player.UnitId = createUnit.UnitId;
                //response.UnitId = createUnit.UnitId;
                //response.Count = createUnit.Count;
                // reply(response);
            }
            catch (Exception e)
            {
               // ReplyError(response, e, reply);
            }
        }
    }
}
