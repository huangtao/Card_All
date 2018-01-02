using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class MatchComponent : Component
    {
        List<long> roomIds = new List<long>();
        public long Create()
        {
            Random r = new Random();
            long ret = r.Next(100000, 999999);
            while(roomIds.Contains(ret))
                ret = r.Next(100000, 999999);
            return ret ;
        }
    }
}
