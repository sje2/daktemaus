using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DakteEngine
{
	public static class Utility
	{
		public static Texture2D GenerateRectangleTexture(GraphicsDevice device, int width, int height, Color color) {
			Texture2D t = new Texture2D (device, width, height);
			Color[] c = new Color[width * height];
			for (int i = 0; i < c.Length; i++) {
				c [i] = color;
			}
			t.SetData (c);

			return t;
		}
	}
}

