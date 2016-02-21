using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DakteMaus
{
	public class KeyboardInput : BaseInput
	{

		private KeyboardState mPrevState;
		
		public KeyboardInput (Game1 host ) : base(host)
		{
			mPrevState = Keyboard.GetState ();
		}

		public override void ProcessInput ()
		{
			KeyboardState state = Keyboard.GetState ();

			if (state.IsKeyDown (Keys.Escape)) {
				mHost.Exit ();
			}
			if (state.IsKeyDown(Keys.Right)) {
				mHost.RunRightCommand ();
			}
			if (state.IsKeyDown(Keys.Left)) {
				mHost.RunLeftCommand ();
			}
			if (state.IsKeyDown(Keys.Space) && ! mPrevState.IsKeyDown(Keys.Space)) {
				mHost.JumpCommand ();
			}

			mPrevState = state;

		}
	}
}

