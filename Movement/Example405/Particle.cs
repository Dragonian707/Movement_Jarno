using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
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
	class Particle : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		Vector2 MaxSpeed;
		float thrustForce;
		Vector2 gravity = new Vector2(0.0f, 50f);

		// constructor + call base constructor
		public Particle(float x, float y, Color color) : base("resources/spaceship.png")
		{
			Position = new Vector2(x, y);
			Scale = new Vector2(0.25f, 0.25f);
			Color = color;
			MaxSpeed = new Vector2(1000, 1000);
			thrustForce = 30f;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			float x = thrustForce * MathF.Cos((float)Rotation);
			float y = thrustForce * MathF.Sin((float)Rotation);
			AddForce(new Vector2(x, y));
			AddForce(gravity);
			// Velocity *= 0.2f;
			Position += Velocity * deltaTime;
			// Velocity = Vector2.Min(Velocity, MaxSpeed);
			// Velocity = Vector2.Max(Velocity, -MaxSpeed);
			WrapEdges();
			// PointToVelocity();
			Rotation = Math.Atan2(Velocity.Y, Velocity.X);
		}

		private void WrapEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// TODO implement...
			if (Position.X > scr_width)
			{
				Position.X = 0;
			}
			else if (Position.X < 0)
			{
				Position.X = scr_width;
			}

			if (Position.Y > scr_height)
			{
				Position.Y = 0;
			}
			else if (Position.Y < 0)
			{
				Position.Y = scr_height;
			}
		}

		// public void addForce(Vector2 force)
		// {
		// 	Acceleration = force;
		// 	Velocity += Acceleration;
		// }

		private void PointToVelocity()
		{
			Rotation = MathF.Atan2(Velocity.Y, Velocity.X);
		}
	}
}
