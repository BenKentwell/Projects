using Azimuth.GameObjects;
using Azimuth.GameStates;

using System.Numerics;

namespace DinoRun
{
	public class PlayState : IGameState
	{
		public string ID => DinoRun.PLAY_STATE_ID;
		public void Load()
		{
			Floor floor = new Floor(new Vector2(0, Azimuth.Config.Get<int>("Window", "height") - 100));
			Dino dino = new Dino(new Vector2(Azimuth.Config.Get<int>("Window", "height") / 4, Azimuth.Config.Get<int>("Window", "height")-200), new Vector2(100, 100));
			GameObjectManager.Spawn(floor);
			GameObjectManager.Spawn(dino);
			
		}

		public void Update(float _deltaTime) { }

		public void Draw() { }

		public void Unload() { }
	}
}