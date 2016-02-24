using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DakteEngine
{
	

	/* Action State
	 * An ActionState describes a list of basic actions that an actor is taking,
	 * and the animations used to represent them.
	 * 
	 * An Action state can loop (repeat animations/actions), or simply fire.
	 * 
	 * An Action state MUST be initiated by a JSON file.
	*/
	public class ActionState
	{

		#region members
		private int mStartMs;			//the gametime in ms the action was started
		private int mElapsedMs;			//current ms of action
		private Animation mAnimation;	
		private Actor mActor;
		private bool mLooper;
		private List<ActorCommand> mCommands;
		#endregion

		#region Properties (READ FROM JSON)
		public string Name;
		public string SpriteSheetPath;
		public float DurationMs;
		public bool Looping;
		public List<ActorCommand> Commands { get { return mCommands; } set { mCommands = value; } }

		#endregion

		#region Constructor
		public ActionState ()
		{
			mCommands = new List<ActorCommand>();	
		}
		#endregion

		#region Public Methods
		public void Start(int gameMs) {
			mStartMs = gameMs;

		}

		public void Update() {
			//now is the time for all good men to come to the aid of their country. 
			//daniele
		}
		#endregion


	}
}

