using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.IO;
using Newtonsoft;

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

		#region JSON
		public static T LoadFromJson<T>(string path) {
			using (Stream fileStream = TitleContainer.OpenStream(path)) {
				using (StreamReader reader = new StreamReader (fileStream)) {
					if (reader != null) {
						string json = reader.ReadToEnd ();

						T ret = Newtonsoft.Json.JsonConvert.DeserializeObject<T> (json);

						return ret;
					}
				}
			}
			return default(T);
		}
		#endregion
	}

}

