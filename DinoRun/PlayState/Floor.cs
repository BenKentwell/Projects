using Azimuth;
using Azimuth.GameObjects;

using Raylib_cs;

using System.Numerics;

namespace DinoRun
{
	public class Floor : GameObject
	{
		public Floor(Vector2 _position)
		{
			position = _position;
		}

		public override void Draw()
		{
			Raylib.DrawLine((int) position.X, (int) position.Y, (int) (position.X + Raylib.GetScreenWidth()), (int) position.Y, Color.DARKGRAY);
		}
	}
}