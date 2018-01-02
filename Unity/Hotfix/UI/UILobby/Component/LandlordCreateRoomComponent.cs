using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
namespace Hotfix
{
    [ObjectEvent]
    public class LandlordCreateRoomComponentEvent : ObjectEvent<LandlordCreateRoomComponent>, IAwake
    {
        public void Awake()
        {
            this.Get().Awake();
        }
    }
    public class LandlordCreateRoomComponent : Component
    {
        ReferenceCollector mRc;
        public void Awake()
        {
            UI ui = this.GetEntity<UI>();
           
            ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
            resourcesComponent.LoadBundle("LandlordCreateRoom.unity3d");
            GameObject bundleGameObject = resourcesComponent.GetAsset<GameObject>("LandlordCreateRoom.unity3d", "LandlordCreateRoom");
            GameObject LandlordCreateRoom = UnityEngine.Object.Instantiate(bundleGameObject);
            LandlordCreateRoom.layer = LayerMask.NameToLayer(LayerNames.UI);
        
            LandlordCreateRoom.transform.SetParent(Hotfix.Scene.GetComponent<UIComponent>().GetCanvas(ui), false);
            mRc = LandlordCreateRoom.GetComponent<ReferenceCollector>();
            Hide();
            Button btn_close = mRc.Get<GameObject>("btn_close").GetComponent<Button>();
            btn_close.onClick.Add(() =>
            {
                Hide();
            });

            Button btn_ok = mRc.Get<GameObject>("btn_ok").GetComponent<Button>();
            btn_ok.onClick.Add(() =>
            {
                SessionComponent.Instance.Session.Send(new C2G_CreateLandlordRoom());
            });

        }
        public override void Dispose()
        {
            base.Dispose();
            if(null != mRc)
            {
                GameObject.Destroy(mRc.gameObject);
                mRc = null;
            }
        }
        public void Hide()
        {
            mRc.gameObject.SetActive(false);
        }
        public void Show()
        {
           mRc.gameObject.SetActive(true);
            mRc.gameObject.transform.SetAsLastSibling();
        }
    }
}
