using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
	[ObjectEvent]
	public class PlayerEvent : ObjectEvent<Player>, IAwake
	{
		public void Awake()
		{
			this.Get().Awake();
		}
	}
    [BsonIgnoreExtraElements]
    public sealed class Player : Entity
	{
        public long RoleId;
        public long UnitId;
        public PlayerBaseInfo BaseInfo = new PlayerBaseInfo();
        [BsonIgnore]
        public Session mSession { get; set; }
		public void Awake()
		{
            RoleId = this.Id;
		}
		
		public override  void Dispose()
		{
			if (this.Id == 0)
			{
				return;
			}
			base.Dispose();
		}
	}
}