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
		float lifeTime;
		Vector2 gravity = new Vector2(0.0f, 50f);
		public Vector2 initPos;
		public bool dead = false;

		// constructor + call base constructor
		public Particle(float x, float y, Color color, int life) : base("resources/spaceship.png")
		{
			Position = new Vector2(x, y);
			initPos = Position;
			Scale = new Vector2(0.25f, 0.25f);
			Color = color;
			MaxSpeed = new Vector2(1000, 1000);
			thrustForce = 30f;
			lifeTime = life;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			AddForce(gravity);
			Position += Velocity * deltaTime;
			Rotation = Math.Atan2(Velocity.Y, Velocity.X);
			lifeTime -= 1 * deltaTime * 60;
			if (lifeTime <= 0)
			{
				dead = true;
			}
		}

		public void Reset(int newLifeTime)
		{
			lifeTime = newLifeTime;
			dead = false;
			Position = initPos;
			Rotation = (float)Math.Atan2(Position.Y, Position.X);
			float X = 50 * MathF.Cos((float)Rotation);
			float Y = 50 * MathF.Sin((float)Rotation);
			Velocity = new Vector2(X, Y);
		}

		private void PointToVelocity()
		{
			Rotation = MathF.Atan2(Velocity.Y, Velocity.X);
		}
	}
}
