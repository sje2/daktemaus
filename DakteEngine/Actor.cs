using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace DakteEngine
{
	public class Actor : Thing
	{

		public Actor (Vector2 size, Vector2 position, Vector2 velocity) : base (size, position, velocity) {	}

		#region Movement Functions
		//Move functions.
		//lifted directly from Matt Makes Games
		//http://mattmakesgames.tumblr.com/post/127890619821/towerfall-physics
		public void MoveX(float amount, Action onCollide) 
		{
			mRemainderX += amount;
			int move = (int) Math.Round (mRemainderX);

			if (move != 0) 
			{
				mRemainderX -= move;
				int sign = Math.Sign (move);
				//int check = sign > 0 ? sign + ( (int) mSize.X ) : sign;
				Vector2 check = sign > 0 ? new Vector2 (sign + ((int)mSize.X), 0) : new Vector2 (sign, 0);
				//try to move one pixel at a time
				while (move != 0) {
					//check for a solid collision
					if (!collideAt (mPosition + check)) {
						//no collision!
						mPosition.X += sign;
						move -= sign;
					} else {
						//collision with a solid!
						if (onCollide != null) {
							onCollide ();
						}
						break;
					}
				}
			}
		}

		public void MoveY(float amount, Action onCollide) 
		{
			mRemainderY += amount;
			int move = (int) Math.Round (mRemainderY);

			if (move != 0) {
				mRemainderY -= move;
				int sign = Math.Sign (move);
				Vector2 check = sign > 0 ? new Vector2 (0, sign + ((int)mSize.Y)) : new Vector2 (0, sign);
				while (move != 0) {
					if (!collideAt (mPosition + check)) {
						mPosition.Y += sign;
						move -= sign;
					} else {
						if (onCollide != null) {
							onCollide ();
						}
						break;
					}
				}
			}
		}

		public void MoveSelf(float deltaSeconds) {
			MoveX (mVelocity.X * deltaSeconds, stopVelocityX);
			MoveY (mVelocity.Y * deltaSeconds, stopVelocityY);
		}

		private void stopVelocityX() {
			mVelocity.X = 0;
		}

		private void stopVelocityY() {
			mVelocity.Y = 0;
		}

		private bool collideAt(Vector2 position) {
			foreach (Solid s in mWorld.Solids) {
				if (s.ContainsPoint(position)) {
					return true;
				}
			}
			return false;
		}

		#endregion
	}
		
}

