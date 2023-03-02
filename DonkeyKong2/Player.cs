using Azimuth.GameObjects;
using Azimuth;

using System.Numerics;

using Raylib_cs;

namespace DonkeyKong2
{
	public class Player : GameObject
	{
		public Vector2 size;
		public List<GameObject> floors;
		public List<GameObject> ladders;

		private float xSpeed = 350;
		private float ySpeed = 100;
		private float yVelocity;
		private float gravity = 9;
		private float jumpMulti = -2;
		
		private bool[] doubleJump = new bool[2];

		public Player(Vector2 _position, Vector2 _size, List<GameObject> _floors, List<GameObject> _ladders)
		{
			position = _position;
			size = _size;
			floors = _floors;
			ladders = _ladders;
		}

		public override void Load()
		{
			
		}

		public override void Draw()
		{
			RaylibExt.DrawTexture(Assets.Find<Texture2D>("Textures/player1"), position.X, position.Y, size.X, size.Y, Color.WHITE);
		}

		public override void Update(float _deltaTime)
		{
			//Gravity applied to player

			// call movement functions
			Movement(_deltaTime);
			// climbable + grounded functions
		}

		public override void Unload() { }

		public bool IsOnGround()
		{
			foreach(Floor floor in floors)
			{
				if(Raylib.CheckCollisionRecs(new Rectangle(floor.position.X, floor.position.Y, floor.size.X, floor.size.Y), new Rectangle(position.X, position.Y, size.X, size.Y)))
				{
					return true;
				}
			}

			return false;
		}

		public bool IsOnClimbable()
		{
			foreach(Ladder ladder in ladders)
				if(Raylib.CheckCollisionRecs(new Rectangle(ladder.position.X, ladder.position.Y, ladder.size.X, ladder.size.Y), new Rectangle(position.X, position.Y, size.X, size.Y)))
				{
					return true;
				}

			return false;
		}

		public void Movement(float _deltaTime)
		{
			
			
			//checking for speed modifier (sprinting)
			xSpeed = !Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) ? 350 : 500;
			
			// Horizontal movement
			if(Raylib.IsKeyDown(KeyboardKey.KEY_A))
				position.X -= xSpeed * _deltaTime;
			if(Raylib.IsKeyDown(KeyboardKey.KEY_D))
				position.X += xSpeed * _deltaTime;
			
			//Checking for Jumping || Gravity Mechanics
			if((Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && IsOnGround()) || (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && doubleJump[1] == false))
			{
				yVelocity = jumpMulti;
				if(doubleJump[0] == false)
					doubleJump[0] = true;
				else doubleJump[1] = true;
			}
			else if(!IsOnGround())
			{
				yVelocity += gravity * _deltaTime*4;
			}

			if(yVelocity > 0 && IsOnGround())
			{
				yVelocity = 0;
				doubleJump[0] = false;
				doubleJump[1] = false;
			}
			
			//Checking for Climbing|| vertical movement
			// if(Raylib.IsKeyDown(KeyboardKey.KEY_W) && IsOnClimbable())
			// {
			// 	yVelocity = 0;
			// 	position.Y -= ySpeed * _deltaTime;
			// }
			//
			// if(Raylib.IsKeyDown(KeyboardKey.KEY_S) && IsOnClimbable())
			// {
			// 	position.Y += ySpeed * _deltaTime;
			// }

			if(IsOnClimbable())
			{
				yVelocity = 0;
				if(Raylib.IsKeyDown(KeyboardKey.KEY_W))
					position.Y -= ySpeed * _deltaTime;
				else if(Raylib.IsKeyDown(KeyboardKey.KEY_S))
					position.Y += ySpeed * _deltaTime;
			}

			position.Y += yVelocity;
		}
	}
}