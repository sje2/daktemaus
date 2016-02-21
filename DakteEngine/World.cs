using System;

using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace DakteEngine
{
	//the world in which a Thing lives.
	public class World
	{
		private List<Actor> mActors;
		private List<Solid> mSolids;

		public List<Actor> Actors { get { return mActors; } }
		public List<Solid> Solids { get { return mSolids; } }

		public World ()
		{
			mActors = new List<Actor> ();
			mSolids = new List<Solid> ();
		}

		public void Update(float deltaSeconds) {
			foreach (Actor actor in mActors) {
				actor.MoveSelf (deltaSeconds);
			}
		}

		public void AddActor(Actor actor) {
			actor.World = this;
			mActors.Add (actor);
		}

		public void AddSolid(Solid solid) {
			solid.World = this;
			mSolids.Add (solid);
		}


	}
}

