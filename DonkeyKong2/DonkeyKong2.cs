using Azimuth;
using Azimuth.GameObjects;

using Raylib_cs;

using System.Numerics;

namespace DonkeyKong2
{
	public class DonkeyKong2 : Game
	{
		public List<GameObject> floors = new List<GameObject>();
		public List<GameObject> ladders = new List<GameObject>();
		
		public override void Load()
		{
			
			Floor floor1 = new Floor(new Vector2(15, Raylib.GetScreenHeight() / 2), new Vector2((float) (Raylib.GetScreenWidth() * 0.8), Raylib.GetScreenHeight() / 20));
			Floor floor2 = new Floor(new Vector2(500, Raylib.GetScreenHeight() / 3), new Vector2((float) (Raylib.GetScreenWidth() * 0.6), Raylib.GetScreenHeight() / 20));
			Ladder ladder1 = new Ladder(new Vector2(floor1.position.X, floor1.position.Y - 200), new Vector2(50, 200));
			
			floors.Add(floor1);
			floors.Add(floor2);
			ladders.Add(ladder1);
			
			Player player = new Player(new Vector2(200, 200), new Vector2(50, 50), floors, ladders);
			
			GameObjectManager.Spawn(player);
			GameObjectManager.Spawn(floor1);
			GameObjectManager.Spawn(floor2);
			GameObjectManager.Spawn(ladder1);
		}

		public override void Unload()
		{
			
		}

		
	}
	
}