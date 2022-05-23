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

		// constructor + call base constructor
		public ParticleSystem(float x, float y) : base()
		{
			Position = new Vector2(x, y);

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
			Random rand = new Random();
			for (int i = 0; i < 100; i++)
			{
				float randX = (float)rand.NextDouble();
				float randY = (float)rand.NextDouble();
				Vector2 pos = new Vector2(randX, randY) * 200;
				pos -= new Vector2(100, 100);
				Particle p = new Particle(pos.X, pos.Y, colors[rand.Next()%colors.Count]);
				particles.Add(p);
				p.Rotation = (float)Math.Atan2(pos.Y, pos.X);
				p.Velocity = new Vector2(0, -20);
				AddChild(p);
			}
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{

		}
	}
}
