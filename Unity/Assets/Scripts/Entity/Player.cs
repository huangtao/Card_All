namespace Model
{
	public sealed class Player : Entity
	{
		public long UnitId { get; set; }
        public PlayerBaseInfo info { get; set; }
		
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