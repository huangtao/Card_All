namespace Model
{
	public class SessionPlayerComponent : Component
	{
		public Player Player;

		public override async void Dispose()
		{
			if (this.Id == 0)
			{
				return;
			}

			base.Dispose();
           await Game.Scene.GetComponent<DBProxyComponent>().Save(Player,false);
			//Game.Scene.GetComponent<PlayerComponent>()?.Remove(this.Player.Id);
		}
	}
}