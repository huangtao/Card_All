using System;
using System.Net;
using Model;
using MongoDB.Bson;

namespace Hotfix
{
	[MessageHandler(AppType.Realm)]
	public class C2R_LoginHandler : AMRpcHandler<C2R_Login, R2C_Login>
	{
		protected override async void Run(Session session, C2R_Login message, Action<R2C_Login> reply)
		{
			Log.Debug(message.ToJson());
			R2C_Login response = new R2C_Login();
			try
			{
                long roleId = 0;
                string szName = string.Empty;
                string szIcon = string.Empty;
                if(message.channel == 0)
                {
                    try
                    {
                        roleId = System.Convert.ToInt64(message.Account);
                        szName = message.Account;
                    }
                    catch
                    {

                    }
                    if (message.channel == 0)
                    {

                    }

                }

				// 随机分配一个Gate
				StartConfig config = Game.Scene.GetComponent<RealmGateAddressComponent>().GetAddress(roleId);
				//Log.Debug($"gate address: {MongoHelper.ToJson(config)}");
				IPEndPoint innerAddress = config.GetComponent<InnerConfig>().IPEndPoint;
				Session gateSession = Game.Scene.GetComponent<NetInnerComponent>().Get(innerAddress);

				// 向gate请求一个key,客户端可以拿着这个key连接gate
				G2R_GetLoginKey g2RGetLoginKey = await gateSession.Call<G2R_GetLoginKey>(new R2G_GetLoginKey() {roleId = roleId,icon=szIcon,mName = szName});

				string outerAddress = config.GetComponent<OuterConfig>().IPEndPoint2.ToString();

				response.Address = outerAddress;
				response.Key = g2RGetLoginKey.Key;
				reply(response);
			}
			catch (Exception e)
			{
				ReplyError(response, e, reply);
			}
		}
	}
}