using System.Numerics;
using Azimuth;
using Azimuth.GameObjects;

using Raylib_cs;

namespace DinoRun
{
	public class Dino : GameObject
	{
		private Texture2D texture = Assets.Find<Texture2D>("Textures/dino");
		public Vector2 size;
		public float gravity = 0.9f;
		public float jumpMulti = -0.1f;
		public float yVelocity;
		public Dino(Vector2 _position, Vector2 _size) : base()
		{
			position = _position;
			size = _size;
		}

		public override void Draw()
		{
			Raylib.DrawTexturePro(texture,new Rectangle(0,0,texture.width, texture.height), new Rectangle(position.X , position.Y , size.X, size.Y), Vector2.Zero, 0, Color.WHITE );
		}

		public override void Update(float _deltaTime)
		{
			Jump();
			 if(position.Y + size.Y > Config.Get<int>("Window", "height") - 100 && yVelocity > 0)
			 {
			 	yVelocity = 0;
			 }
			else if (position.Y + size.Y < Config.Get<int>("Window", "height") - 100)
			{
				yVelocity += gravity * _deltaTime;
			}

			

			position.Y += yVelocity;
		}

		public void Jump()
		{
			if(Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && position.Y + size.Y > Config.Get<int>("Window", "height") - 200)
			{
				yVelocity = jumpMulti;
			}
		}
	}
}