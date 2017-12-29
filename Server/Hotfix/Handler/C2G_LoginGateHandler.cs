using System;
using Model;

namespace Hotfix
{
	[MessageHandler(AppType.Gate)]
	public class C2G_LoginGateHandler : AMRpcHandler<C2G_LoginGate, G2C_LoginGate>
	{
		protected override async void Run(Session session, C2G_LoginGate message, Action<G2C_LoginGate> reply)
		{
			G2C_LoginGate response = new G2C_LoginGate();
			try
			{
                GateSessionKeyComponent.GateSessionInfo info = Game.Scene.GetComponent<GateSessionKeyComponent>().Get(message.Key);

              
				if (info == null)
				{
					response.Error = ErrorCode.ERR_ConnectGateKeyError;
					response.Message = "Gate key验证失败!";
					reply(response);
					return;
				}
                PlayerComponent playerComponet = Game.Scene.GetComponent<PlayerComponent>();
                Player player = playerComponet.Get(info.RoleId);
                if(null == player)
                {
                  player = await  Game.Scene.GetComponent<DBProxyComponent>().Query<Player>(info.RoleId);
                    if(null == player)
                        player = EntityFactory.CreateWithId<Player>(info.RoleId);
                    playerComponet.Add(player);
                    player.mSession = session;
                    
                   
                }
                else
                {
                    await player.mSession.GetComponent<ActorComponent>().RemoveLocation();
                    player.mSession.Dispose();
                  
                   player.mSession = session;
                }
                player.BaseInfo.roleId = info.RoleId;
                player.BaseInfo.Name = info.Name;
                player.BaseInfo.Icon = info.Icon;
				session.AddComponent<SessionPlayerComponent>().Player = player;
				await session.AddComponent<ActorComponent, IEntityActorHandler>(new GateSessionEntityActorHandler()).AddLocation();

				response.PlayerId = player.Id;
                response.info = player.BaseInfo;
				reply(response);
			}
			catch (Exception e)
			{
				ReplyError(response, e, reply);
			}
		}
	}
}