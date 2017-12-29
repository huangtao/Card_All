using System.Collections.Generic;

namespace Model
{
	public class RealmGateAddressComponent : Component
	{
		public readonly List<StartConfig> GateAddress = new List<StartConfig>();
        Dictionary<long, StartConfig> mLoginedAdrees = new Dictionary<long, StartConfig>();
		public StartConfig GetAddress(long roleId)
		{
            StartConfig ret = null;
            if(mLoginedAdrees.TryGetValue(roleId,out ret))
            {
                return ret;
            }
            else
            {
                int n = RandomHelper.RandomNumber(0, this.GateAddress.Count);
                ret = this.GateAddress[n];
                mLoginedAdrees[roleId] = ret;
                return ret;
            }
		}
        public void Remove(long roleId)
        {
            if (mLoginedAdrees.ContainsKey(roleId))
                mLoginedAdrees.Remove(roleId);
        }
	}
}
