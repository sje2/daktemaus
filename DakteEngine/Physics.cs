using System;
using Microsoft.Xna.Framework;


namespace DakteEngine
{

	public class Physics
	{

		public static readonly float ACC_GRAVITY = -400;	//px/s^2
		public static readonly Vector2 ACC_GRAVITY_VEC2 = new Vector2(0, ACC_GRAVITY);

		public Physics () { }

		public void Update(World world, float deltaSeconds) 
		{

			foreach (Actor actor in world.Actors) {
				applyGravity (actor, deltaSeconds);
			}

		}

		private void applyGravity(Thing thing, float deltaSeconds) 
		{
			thing.Accelerate (deltaSeconds * ACC_GRAVITY_VEC2);
		}

		private void applyFriction(Thing thing, float deltaSeconds)
		{
			//TODO: apply friction
		}
	}
}

