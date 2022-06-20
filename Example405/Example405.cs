using System;
using System.Numerics;
using Raylib_cs;
using System.Collections.Generic;

namespace Movement
{
	class Example405 : SceneNode
	{
		// private fields
		private ParticleSystem particlesystem01;
		private ParticleSystem particlesystem02;
		private Vector2 mouse;
		private List<ParticleSystem> systems = new List<ParticleSystem>();

		// constructor + call base constructor
		public Example405(String t) : base(t)
		{
			// particlesystem01 = new ParticleSystem(320, 360);
			// systems.Add(particlesystem01);
			// AddChild(particlesystem01);

			// particlesystem02 = new ParticleSystem(960, 360);
			// systems.Add(particlesystem02);
			// AddChild(particlesystem02);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
			{
				mouse = Raylib.GetMousePosition();
				particles(deltaTime);
			}
		}

		private void particles(float deltaTime)
		{
			particlesystem01 = new ParticleSystem(mouse.X, mouse.Y);
			systems.Add(particlesystem01);
			AddChild(particlesystem01);
		}

	} // class

} // namespace
