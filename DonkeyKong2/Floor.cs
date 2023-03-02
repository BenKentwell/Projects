using Azimuth.GameObjects;
using Raylib_cs;
using System.Numerics;
using Azimuth;

namespace DonkeyKong2
{
	public class Floor : GameObject
	{
		public Vector2 size;
		public Floor(Vector2 _position, Vector2 _size) : base()
		{

			position = _position;
			size = _size;
		}

		public override void Update(float _deltaTime)
		{
			
		}

		public override void Draw()
		{
			RaylibExt.DrawTexture(Assets.Find<Texture2D>("Textures/pillar"), position.X, position.Y, size.X, size.Y, Color.WHITE);
		}
		
	}
}