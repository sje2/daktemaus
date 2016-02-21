using System;

using Microsoft.Xna.Framework.Graphics;

namespace DakteEngine
{
	public class Animation
	{
		#region members
		//rate of change
		private float mSpeed;
		//just a texture, soon to be replaced with a list of them or a texture atlas
		private Texture2D mTexture;
		#endregion

		#region Properties
		public float Speed { get { return mSpeed; } set{ mSpeed = value; } }
		public Texture2D Texture { get { return mTexture; } set { mTexture = value; } }
		#endregion

		public Animation (Texture2D texture, float speed)
		{
			mTexture = texture;
			mSpeed = speed;
		}
	}
}

