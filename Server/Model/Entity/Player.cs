namespace Model
{
	[ObjectEvent]
	public class PlayerEvent : ObjectEvent<Player>, IAwake<long>
	{
		public void Awake(long roleId)
		{
			this.Get().Awake(roleId);
		}
	}

	public sealed class Player : Entity
	{
		public long RoleId { get; private set; }
		
		public long UnitId { get; set; }
        public PlayerBaseInfo BaseInfo = new PlayerBaseInfo();
        public Session mSession { get; set; }
		public void Awake(long roleId)
		{
			this.RoleId = roleId;
		}
		
		public override void Dispose()
		{
			if (this.Id == 0)
			{
				return;
			}

			base.Dispose();
		}
	}
}