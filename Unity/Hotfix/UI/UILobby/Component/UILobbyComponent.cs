﻿using System;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Hotfix
{
	[ObjectEvent]
	public class UILobbyComponentEvent : ObjectEvent<UILobbyComponent>, IAwake
	{
		public void Awake()
		{
			this.Get().Awake();
		}
	}
	
	public class UILobbyComponent : Component
	{

        RawImage icon;
        Text ID, Name;
       // LandlordCreateRoom mCreatRoom = new LandlordCreateRoom();
		public void Awake()
		{
			ReferenceCollector rc = this.GetEntity<UI>().GameObject.GetComponent<ReferenceCollector>();
            icon = rc.Get<GameObject>("icon").GetComponent<RawImage>();
            ID = rc.Get<GameObject>("ID").GetComponent<Text>();
            Name = rc.Get<GameObject>("Name").GetComponent<Text>();
            PlayerComponent playerComponent = Game.Scene.GetComponent<PlayerComponent>();
            ID.text =$"ID:{playerComponent.MyPlayer.info.roleId}";
            Name.text = $"{playerComponent.MyPlayer.info.roleId}";
            this.GetEntity<UI>().AddComponent<LandlordCreateRoomComponent>();
           // mCreatRoom.Awake(rc.Get<GameObject>("LandlordCreateRoom").GetComponent<ReferenceCollector>());
            Button btn_Landlord= rc.Get<GameObject>("btn_Landlord").GetComponent<Button>();
            btn_Landlord.onClick.Add(() =>
            {
                this.GetEntity<UI>().GetComponent<LandlordCreateRoomComponent>().Show();
               // mCreatRoom.Show();
            });
            //GameObject sendBtn = rc.Get<GameObject>("Send");
            //GameObject sendRpcBtn = rc.Get<GameObject>("SendRpc");
            //sendBtn.GetComponent<Button>().onClick.Add(this.OnSend);
            //sendRpcBtn.GetComponent<Button>().onClick.Add(this.OnSendRpc);

            //GameObject transfer1Btn = rc.Get<GameObject>("Transfer1");
            //GameObject transfer2Btn = rc.Get<GameObject>("Transfer2");
            //transfer1Btn.GetComponent<Button>().onClick.Add(this.OnTransfer1);
            //transfer2Btn.GetComponent<Button>().onClick.Add(this.OnTransfer2);

            //enterMap = rc.Get<GameObject>("EnterMap");
            //enterMap.GetComponent<Button>().onClick.Add(this.EnterMap);

            //this.text = rc.Get<GameObject>("Text").GetComponent<Text>();
        }

		//private void OnSend()
		//{
		//	// 发送一个actor消息
		//	SessionComponent.Instance.Session.Send(new Actor_Test() { Info = "message client->gate->map->gate->client" });
		//}

		//private async void OnSendRpc()
		//{
		//	try
		//	{
		//		// 向actor发起一次rpc调用
		//		Actor_TestResponse response = await SessionComponent.Instance.Session.Call<Actor_TestResponse>(new Actor_TestRequest() { request = "request actor test rpc" });
		//		Log.Info($"recv response: {MongoHelper.ToJson(response)}");
		//	}
		//	catch (Exception e)
		//	{
		//		Log.Error(e.ToStr());
		//	}
		//}

		//private async void OnTransfer1()
		//{
		//	try
		//	{
		//		Actor_TransferResponse response = await SessionComponent.Instance.Session.Call<Actor_TransferResponse>(new Actor_TransferRequest() {MapIndex = 0});
		//		Log.Info($"传送成功! {MongoHelper.ToJson(response)}");
		//	}
		//	catch (Exception e)
		//	{
		//		Log.Error(e.ToStr());
		//	}
		//}

		//private async void OnTransfer2()
		//{
		//	Actor_TransferResponse response = await SessionComponent.Instance.Session.Call<Actor_TransferResponse>(new Actor_TransferRequest() { MapIndex = 1 });
		//	Log.Info($"传送成功! {MongoHelper.ToJson(response)}");
		//}

		//private async void EnterMap()
		//{
		//	try
		//	{
		//		G2C_EnterMap g2CEnterMap = await SessionComponent.Instance.Session.Call<G2C_EnterMap>(new C2G_EnterMap());
		//		//Hotfix.Scene.GetComponent<UIComponent>().Remove(UIType.UILobby);
		//	}
		//	catch (Exception e)
		//	{
		//		Log.Error(e.ToStr());
		//	}	
		//}
	}
}
