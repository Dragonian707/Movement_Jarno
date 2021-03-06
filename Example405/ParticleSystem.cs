using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
using Raylib_cs; // Color

namespace Movement
{
	class ParticleSystem : Node
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		List<Particle> particles;
		private List<Color> colors;
		private Vector2 Velocity;
		private Vector2 Acceleration;
		private int liveTime;
		internal bool isAlive;
		Random rand = new Random();

		// constructor + call base constructor
		public ParticleSystem(float x, float y) : base()
		{
			Position = new Vector2(x, y);
			liveTime = 2;

			colors = new List<Color>();
			colors.Add(Color.WHITE);
			colors.Add(Color.ORANGE);
			colors.Add(Color.RED);
			colors.Add(Color.BLUE);
			colors.Add(Color.GREEN);
			colors.Add(Color.BEIGE);
			colors.Add(Color.SKYBLUE);
			colors.Add(Color.YELLOW);
			colors.Add(Color.VIOLET);
			colors.Add(Color.MAROON);
			colors.Add(Color.LIME);

			particles = new List<Particle>();
			for (int i = 0; i < 100; i++)
			{
				float randX = (float)rand.NextDouble();
				float randY = (float)rand.NextDouble();
				Vector2 pos = new Vector2(randX, randY) * 200;
				pos -= new Vector2(100, 100);
				Particle p = new Particle(pos.X, pos.Y, colors[rand.Next()%colors.Count], rand.Next(150, 301));
				particles.Add(p);
				p.Rotation = (float)Math.Atan2(pos.Y, pos.X);
				float X = 50 * MathF.Cos((float)p.Rotation);
				float Y = 50 * MathF.Sin((float)p.Rotation);
				p.Velocity = new Vector2(X, Y);
				AddChild(p);
			}
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			foreach (Particle p in particles)
			{
				if (p.dead)
				{
					p.Reset((int)rand.Next(150, 301));
				}
			}
		}
	}
}
