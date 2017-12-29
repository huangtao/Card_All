using System.Collections.Generic;

namespace Model
{
	public class GateSessionKeyComponent : Component
	{
        public class GateSessionInfo
        {
            public long RoleId;
            public string Name;
            public string Icon;
        }
		private readonly Dictionary<long, GateSessionInfo> sessionKey = new Dictionary<long, GateSessionInfo>();
		
		public void Add(long key, long roleId,string szName,string szIcon)
		{
            GateSessionInfo info = new GateSessionInfo();
            info.RoleId = roleId;
            info.Name = szName;
            info.Icon = szIcon;

            this.sessionKey.Add(key, info);
			this.TimeoutRemoveKey(key);
		}

		public GateSessionInfo Get(long key)
		{
            GateSessionInfo info = null;
			this.sessionKey.TryGetValue(key, out info);
			return info;
		}

		public void Remove(long key)
		{
			this.sessionKey.Remove(key);
		}

		private async void TimeoutRemoveKey(long key)
		{
			await Game.Scene.GetComponent<TimerComponent>().WaitAsync(20000);
			this.sessionKey.Remove(key);
		}
	}
}
