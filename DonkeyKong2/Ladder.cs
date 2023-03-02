using Azimuth;
using Azimuth.GameObjects;

using Raylib_cs;

using System.Numerics;
namespace DonkeyKong2
{
	public class Ladder : GameObject
	{
		public Vector2 size;
		
		public Ladder(Vector2 _position, Vector2 _size)
		{
			position = _position;
			size = _size;
		}

		public override void Update(float _deltaTime)
		{
			
		}

		public override void Load()
		{
			
		}

		public override void Draw()
		{
			RaylibExt.DrawTexture(Assets.Find<Texture2D>("Textures/ladder"), position.X, position.Y, size.X, size.Y, Color.WHITE);
		}
	}
}