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
    public class LandlordCreateRoom : IAwake<ReferenceCollector>
    {
        ReferenceCollector mRc;
        public void Awake(ReferenceCollector a)
        {
            mRc = a;
            Hide();
            Button btn_close = mRc.Get<GameObject>("btn_close").GetComponent<Button>();
            btn_close.onClick.Add(() =>
            {
                Hide();
            });
        }
        public void Hide()
        {
            mRc.gameObject.SetActive(false);
        }
        public void Show()
        {
            mRc.gameObject.SetActive(true);
        }
    }
}
