using System;

using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;

namespace DakteEngine
{
	//Basic Physics entity.
	public class Thing
	{
		//movement remainders
		protected float mRemainderX;
		protected float mRemainderY;

		protected Vector2 mSize;
		protected Vector2 mVelocity;
		protected Vector2 mPosition;
		protected World mWorld;

		protected Animation mAnimation;

		#region Properties
		public Vector2 Velocity { get { return mVelocity; } set { mVelocity = value; } }
		public Vector2 Position { get { return mPosition; } set { mPosition = value; } }
		public Vector2 Size { get { return mSize; } set { mSize = value; } }
		public World World { get { return mWorld; } set { mWorld = value; } }

		public Animation Animation { get { return mAnimation; } set { mAnimation = value; } }

		#endregion Properties

		#region CONSTRUCTORS
		public Thing () : this(new Vector2(0, 0), new Vector2 (0, 0), new Vector2 (0, 0)) { }

		public Thing(Vector2 size, Vector2 position, Vector2 velocity) 
		{
			mVelocity = velocity;
			mPosition = position;
			mSize = size;

			mRemainderX = 0.0f;
			mRemainderY = 0.0f;
		}
		#endregion CONSTRUCTORS

		#region Public Methods
		public void Accelerate(Vector2 delta, bool floorZero = false)
		{
			if (floorZero) {
				mVelocity.X = addWithZeroFloor (mVelocity.X, delta.X);
				mVelocity.Y = addWithZeroFloor (mVelocity.Y, delta.Y);
			} else {
				Velocity = Velocity + delta;
			}
		}

		public bool ContainsPoint(Vector2 point) {
			if (point.Y > mPosition.Y + mSize.Y)
				return false;
			if (point.Y < mPosition.Y)
				return false;
			if (point.X > mPosition.X + mSize.X)
				return false;
			if (point.X < mPosition.X)
				return false;
			return true;
		}

		#endregion Public Methods

		#region private methods
		private float addWithZeroFloor(float orig, float plus) {
			if (orig < 0) {
				return Math.Min (orig + plus, 0f);
			} else {
				return Math.Max (orig + plus, 0f);
			}
		}
		#endregion private methods



	}
}

