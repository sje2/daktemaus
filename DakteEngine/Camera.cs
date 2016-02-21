using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DakteEngine
{
	public class Camera
	{
		public Vector2 Position { get; set; }
		public Vector2 Size {get; set;}

		public Texture2D Background{ get; set; }


		public Camera (Vector2 position, Vector2 size, Texture2D background = null)
		{ 
			Position = position; 
			Size = size; 
			Background = background;
		}

		public Vector2 WorldToCameraCoordinates(Vector2 worldCoordinates, Vector2 worldSize) {
			Vector2 cameraCoordinates = new Vector2 (
				worldCoordinates.X - Position.X,
				Size.Y - (worldCoordinates.Y - Position.Y) - worldSize.Y
			);
			return cameraCoordinates;
		}

		public void DrawWorld(SpriteBatch batch, World world) {
			//TODO: Add your drawing code here
			batch.Begin();

			if (Background != null) {
				batch.Draw (Background, Constants.ZERO_VEC2 );
			}

			foreach (Solid solid in world.Solids) {
				batch.Draw (solid.Animation.Texture, WorldToCameraCoordinates(solid.Position, solid.Size));
			}

			foreach (Actor actor in world.Actors) 
			{
				batch.Draw(actor.Animation.Texture, WorldToCameraCoordinates(actor.Position, actor.Size));
			}


			batch.End ();
		}

	}
}

