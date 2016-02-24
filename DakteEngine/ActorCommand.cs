using System;
using Microsoft.Xna.Framework;

namespace DakteEngine
{
	public enum ActorCommandType { Move, Accelerate };

	/* class to collect the information necessary to schedule a basic command
	 * to an Actor.  This is used in an ActionState.
	 * 
	*/
	public class ActorCommand
	{

		public ActorCommandType What { get; set; }
		public float WhenMs { get; set; }
		public float WhereX { get; set; }
		public float WhereY { get; set; }


		public ActorCommand () : this (ActorCommandType.Move, 0, Constants.ZERO_VEC2.X, Constants.ZERO_VEC2.Y) 
		{ }

		public ActorCommand (ActorCommandType what, float whenMs, float whereX, float whereY) {
			What = what;
			WhenMs = whenMs;
			WhereX = whereX;
			WhereY = whereY;
		}


	}
}

