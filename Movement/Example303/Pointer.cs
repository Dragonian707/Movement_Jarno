using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Color

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
	class Pointer : SpriteNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		private Vector2 Velocity;
		private Vector2 Acceleration;
		private Vector2 MaxSpeed = new Vector2(700, 700);
		private float angle;

		// constructor + call base constructor
		public Pointer() : base("resources/spaceship.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);
			Color = Color.DARKPURPLE;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			PointToMouse(deltaTime);
			//BounceEdges();
		}

		// your own private methods
		private void PointToMouse(float deltaTime)
		{
			// Or just implement it in Example 110 Follower

			Vector2 mouse = Raylib.GetMousePosition();
			// Console.WriteLine(mouse);

			//Position = mouse; // incorrect!!

			  // incorrect!!

			// TODO implement
			Position += Velocity * deltaTime;
			Acceleration = mouse - Position;
			Vector2.Normalize(Acceleration);
			Acceleration /= 200f;
			Velocity += Acceleration;
			Velocity = Vector2.Min(Velocity, MaxSpeed);
			Velocity = Vector2.Max(Velocity, -MaxSpeed);
			angle = MathF.Atan2(Velocity.Y, Velocity.X);
			Rotation = angle;
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// TODO implement...
			if (Position.X > scr_width)
			{
				// ...
			}
		}

	}
}
